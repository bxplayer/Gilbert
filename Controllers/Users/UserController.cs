using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gilbert.Models;
using System.Data.Entity.Validation;

namespace Gilbert.Controllers.Users
{
    public class UserController : Controller
    {
        private GilbertEntities db = new GilbertEntities();

        // GET: User
        public async Task<ActionResult> Index()
        {
            return View(await db.USR_User.ToListAsync());
        }

        

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Email,UserName,UserLastName,Telephone,Password")] USR_User uSR_User)
        {
            //try
            //{
            
                if (ModelState.IsValid)
                {

                    var email = db.USR_User.FirstOrDefault(s => s.Email == uSR_User.Email);
                    if(email == null)
                    {
                        uSR_User.Password = Auxiliar.Auxiliar.GetMD5(uSR_User.Password);
                        db.USR_User.Add(uSR_User);
                        await db.SaveChangesAsync();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("Email", "Mail duplicado");
                        return View(uSR_User);
                    }


                }

            //}
            //catch (DbEntityValidationException e)
            //{
            //    foreach (var eve in e.EntityValidationErrors)
            //    {
            //        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
            //            eve.Entry.Entity.GetType().Name, eve.Entry.State);
            //        foreach (var ve in eve.ValidationErrors)
            //        {
            //            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
            //                ve.PropertyName, ve.ErrorMessage);
            //        }
            //    }
            //    throw;
            //}

            return View(uSR_User);
        }

        // GET: User/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USR_User uSR_User = await db.USR_User.FindAsync(id);
            if (uSR_User == null)
            {
                return HttpNotFound();
            }
            return View(uSR_User);
        }

        // POST: User/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Email,UserName,UserLastName,Telephone,UserPhoto,Password,IDStatus")] USR_User uSR_User)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSR_User).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(uSR_User);
        }


        public ActionResult Login(string id = null)
        {                 
            ViewBag.Redirect = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Login(string email, string password, string redirect = null)
        {
            if (ModelState.IsValid)
            {
                var f_password = Auxiliar.Auxiliar.GetMD5(password);
                var data = db.USR_User.Where(s => s.Email.Equals(email) && s.Password.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    //Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["idUser"] = data.FirstOrDefault().ID;

                    if (!string.IsNullOrEmpty(redirect))
                    {
                        return RedirectToAction("Index","Job",new {id = redirect });
                    }

                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }

        protected override void Dispose(bool disposing)
        {

            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
