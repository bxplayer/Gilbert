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

namespace Gilbert.Controllers.Users
{
    public class UserController : Controller
    {
        private GilbertEntities db = new GilbertEntities();

        // GET: User/Create/
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Email,UserName,UserLastName,Telephone,UserPhoto,Password,IDStatus")] USR_User uSR_User)
        {
            if (ModelState.IsValid)
            {
                db.USR_User.Add(uSR_User);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

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
