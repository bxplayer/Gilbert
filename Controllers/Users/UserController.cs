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
using Newtonsoft.Json;

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
        public ActionResult Registration()
        {
            //USR_User uSR_User = new USR_User();
            //uSR_User.isUser = true;                
            //return View(uSR_User);
            return View();
        }

        // POST: User/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Registration([Bind(Include = "ID,Email,UserName,UserLastName,Telephone,Password")] USR_User uSR_User)
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


        public ActionResult Login()
        {                 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Login(string email, string password, string id = null)
        {
            if (ModelState.IsValid)
            {
                var f_password = Auxiliar.Auxiliar.GetMD5(password);
                var data = db.USR_User.Where(s => s.Email.Equals(email) && s.Password.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["FullName"] = data.FirstOrDefault().UserName + " " + data.FirstOrDefault().UserLastName;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["IDUser"] = data.FirstOrDefault().ID;
                    Session["User"] = true;

                    if (!string.IsNullOrEmpty(id))
                    {
                        return RedirectToAction("Index","Job",new { id = id });
                    }

                    return RedirectToAction("Index","Home");
                }

                var dataCR = db.CR_User.Where(s => s.Email.Equals(email) && s.Password.Equals(f_password)).ToList();
                if (dataCR.Count() > 0)
                {
                    //add session
                    Session["FullName"] = dataCR.FirstOrDefault().UserName + " " + dataCR.FirstOrDefault().UserLastName;
                    Session["Email"] = dataCR.FirstOrDefault().Email;
                    Session["IDUser"] = dataCR.FirstOrDefault().ID;
                    Session["IDCompany"] = dataCR.FirstOrDefault().IDCompany;
                    Session["UserCR"] = true;

                    return RedirectToAction("Index", "Employ");
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


        public ActionResult Profile(string id = null)
        {
            if (Session["IDUser"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (id != null)
            {
                ViewBag.redirect = id;
            }

            long idUser = (long)Session["IDUser"];
            if (idUser == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USR_CV_Header uSR_CV_Header = db.USR_CV_Header.FirstOrDefault(x => x.IDUser == idUser);            

            if (uSR_CV_Header == null)
            {
                ViewBag.IDState = new SelectList(db.MD_State, "ID", "SDescrip");
                ViewBag.IDUser = new SelectList(db.USR_User, "ID", "Email");
                return View();
            }

            ViewBag.IDState = new SelectList(db.MD_State, "ID", "SDescrip", uSR_CV_Header.IDState);
            ViewBag.IDUser = new SelectList(db.USR_User, "ID", "Email", uSR_CV_Header.IDUser);
            return View(uSR_CV_Header);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Profile([Bind(Include = "Street,StreetNumber,PostCode,IDState,IDNationality,Birthdate,Age")] USR_CV_Header uSR_CV_Header, string redirect = null)
        {



            if (ModelState.IsValid)
            {
                long id = (long)Session["IDUser"];
                uSR_CV_Header.IDUser = id;
                uSR_CV_Header.IDStatus = 1;
                

                USR_CV_Header usr_CV_Header = db.USR_CV_Header.AsNoTracking().FirstOrDefault(x => x.IDUser == id);
                if (usr_CV_Header == null)
                {                    
                    db.USR_CV_Header.Add(uSR_CV_Header);                    
                }
                else
                {
                    uSR_CV_Header.ID = usr_CV_Header.ID;
                    db.Entry(uSR_CV_Header).State = EntityState.Modified;                    
                }

                await db.SaveChangesAsync();

                if (!string.IsNullOrEmpty(redirect))
                {
                    return RedirectToAction("Index", "Job", new { id = redirect });
                }
            }


     

            ViewBag.IDState = new SelectList(db.MD_State, "ID", "SDescrip", uSR_CV_Header.IDState);
            ViewBag.IDUser = new SelectList(db.USR_User, "ID", "Email", uSR_CV_Header.IDUser);
            return View(uSR_CV_Header);
        }



        public ActionResult CV()
        {
            ViewBag.IDEducationSegment = new SelectList(db.MD_EducationSegment, "ID", "SDescrip");
            ViewBag.IDEducationLevel = new SelectList(db.MD_EducationLevel, "ID", "SDescrip");
            ViewBag.IDEducationStatus = new SelectList(db.MD_EducationStatus, "ID", "SDescrip");
            ViewBag.IDPosition = new SelectList(db.MD_Position, "ID", "SDescrip");
            return View();
        }

        [HttpPost]
        public JsonResult addExperience(string exp)
        {
            long id = (long)Session["IDUser"];            
            USR_CV_Header usr_CV_Header = db.USR_CV_Header.AsNoTracking().FirstOrDefault(x => x.IDUser == id);
            if (usr_CV_Header != null)
            {
                USER_CV_WorkExperience uSER_CV_WorkExperience = JsonConvert.DeserializeObject<USER_CV_WorkExperience>(exp);
                uSER_CV_WorkExperience.IDCVHeader = usr_CV_Header.ID;
                uSER_CV_WorkExperience.IDStatus = 1;
                db.USER_CV_WorkExperience.Add(uSER_CV_WorkExperience);
                db.SaveChanges();
                
                Parser_CR_AD_Header parser_CR_AD_Header = new Parser_CR_AD_Header();
                parser_CR_AD_Header.StartDate = uSER_CV_WorkExperience.StartDate;
                parser_CR_AD_Header.FinishDate = (DateTime)uSER_CV_WorkExperience.FinishDate;
                parser_CR_AD_Header.TaskDescrip = uSER_CV_WorkExperience.TaskDescrip;
                parser_CR_AD_Header.PositionDescrip = uSER_CV_WorkExperience.PositionDescrip;
                parser_CR_AD_Header.PositionName = db.MD_Position.FirstOrDefault( x => x.ID == uSER_CV_WorkExperience.IDPosition).LDescrip;

                return Json(new { success = true, response = parser_CR_AD_Header }, JsonRequestBehavior.AllowGet);//JsonConvert.SerializeObject("{success: true}");//Json(uSER_CV_WorkExperience, JsonRequestBehavior.AllowGet);
            }
            
            return Json(new { success = false, responseText = "Error" }, JsonRequestBehavior.AllowGet);
        }

        
        public JsonResult getExperience()
        {
            long id = (long)Session["IDUser"];
            USR_CV_Header usr_CV_Header = db.USR_CV_Header.FirstOrDefault(x => x.IDUser == id);
            List<Parser_CR_AD_Header> parser_CR_AD_Header = db.USER_CV_WorkExperience.Where(x => x.IDCVHeader == usr_CV_Header.ID).Select(x =>
                
                new Parser_CR_AD_Header()
                {
                    StartDate = x.StartDate,
                    FinishDate = (DateTime)x.FinishDate,
                    PositionDescrip = x.PositionDescrip,
                    TaskDescrip = x.TaskDescrip,
                    PositionName = x.MD_Position.LDescrip
                }

                ).ToList();

            return Json(new { success = true, response = parser_CR_AD_Header }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult addEducation(string edu)
        {
            long id = (long)Session["IDUser"];
            USR_CV_Header usr_CV_Header = db.USR_CV_Header.AsNoTracking().FirstOrDefault(x => x.IDUser == id);
            if (usr_CV_Header != null)
            {
                USER_CV_Education uSER_CV_Education = JsonConvert.DeserializeObject<USER_CV_Education>(edu);
                uSER_CV_Education.IDCVHeader = usr_CV_Header.ID;
                uSER_CV_Education.IDStatus = 1;
                db.USER_CV_Education.Add(uSER_CV_Education);
                db.SaveChanges();


                Parser_CR_AD_Education parser_CR_AD_Education = new Parser_CR_AD_Education();
                parser_CR_AD_Education.StartDate = uSER_CV_Education.StartDate;
                parser_CR_AD_Education.FinishDate = (DateTime)uSER_CV_Education.FinishDate;
                parser_CR_AD_Education.EducationSegment = db.MD_EducationSegment.FirstOrDefault(x => x.ID == uSER_CV_Education.IDEducationSegment).LDescrip;
                parser_CR_AD_Education.EducationLevel = db.MD_EducationLevel.FirstOrDefault(x => x.ID == uSER_CV_Education.IDEducationLevel).LDescrip;
                parser_CR_AD_Education.EducationStatus = db.MD_EducationStatus.FirstOrDefault(x => x.ID == uSER_CV_Education.IDEducationStatus).LDescrip;
                parser_CR_AD_Education.PlaceDescrip = uSER_CV_Education.PlaceDescrip;


                return Json(new { success = true, response = parser_CR_AD_Education }, JsonRequestBehavior.AllowGet);//JsonConvert.SerializeObject("{success: true}");//Json(uSER_CV_WorkExperience, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = false, responseText = "Error" }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getEducation()
        {
            long id = (long)Session["IDUser"];
            USR_CV_Header usr_CV_Header = db.USR_CV_Header.FirstOrDefault(x => x.IDUser == id);
            List<Parser_CR_AD_Education> parser_CR_AD_Education = db.USER_CV_Education.Where(x => x.IDCVHeader == usr_CV_Header.ID).Select(x =>

                new Parser_CR_AD_Education()
                {
                    StartDate = x.StartDate,
                    FinishDate = (DateTime)x.FinishDate,
                    EducationSegment = x.MD_EducationSegment.LDescrip,
                    EducationLevel = x.MD_EducationLevel.LDescrip,
                    EducationStatus = x.MD_EducationStatus.LDescrip,
                    PlaceDescrip = x.PlaceDescrip
                }

                ).ToList();

            return Json(new { success = true, response = parser_CR_AD_Education }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ViewCV(string UserID)
        {
            long user_id = Convert.ToInt64(UserID);
            //USR_User uSR_User = db.USR_User.FirstOrDefault(x => x.ID == user_id);
            USR_CV_Header usr_CV_Header = db.USR_CV_Header.FirstOrDefault(x => x.IDUser == user_id);
            ViewUser viewUser = new ViewUser();
            if (usr_CV_Header != null)
            {
                viewUser.Email = usr_CV_Header.USR_User.Email;
                viewUser.UserName = usr_CV_Header.USR_User.UserName;
                viewUser.UserLastName = usr_CV_Header.USR_User.UserLastName;
                viewUser.Telephone = usr_CV_Header.USR_User.Telephone;
                viewUser.Street = usr_CV_Header.Street;
                viewUser.StreetNumber = usr_CV_Header.StreetNumber;
                viewUser.PostCode = usr_CV_Header.PostCode;
                viewUser.State = usr_CV_Header.MD_State.LDescrip;
                viewUser.Nationality = usr_CV_Header.MD_State.MD_Country.LDescrip;
                viewUser.Birthdate = usr_CV_Header.Birthdate;
                viewUser.Age = usr_CV_Header.Age;
                viewUser.ViewUserEducation = usr_CV_Header.USER_CV_Education.Select(x => new ViewUserEducation()
                {
                    StartDate = x.StartDate,
                    FinishDate = x.FinishDate,
                    EducationSegment = x.MD_EducationSegment.LDescrip,
                    EducationLevel = x.MD_EducationLevel.LDescrip
                }).ToList();
                viewUser.ViewUserWorkExperience = usr_CV_Header.USER_CV_WorkExperience.Select(x => new ViewUserWorkExperience()
                {
                    StartDate = x.StartDate,
                    FinishDate = x.FinishDate,
                    Position = x.MD_Position.LDescrip,
                    PositionDescrip = x.PositionDescrip,
                    TaskDescrip = x.TaskDescrip
                }).ToList();
            }


            return Json(new { success = true, response = viewUser }, JsonRequestBehavior.AllowGet);
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
