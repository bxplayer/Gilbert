using Gilbert.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Gilbert.Controllers
{
    public class JobController : Controller
    {
        private GilbertEntities db = new GilbertEntities();
        private const long IDTEST = 2;
        // GET: Job

        //[Route("Job/{uniqueID:string?}")]

       
        public ActionResult Index(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return View(Auxiliar.ViewsPath.JobPath("unknown"));
            }

            CR_AD_Header cR_AD_Header = db.CR_AD_Header.Where(x => x.Unique_ID.ToString() == id).FirstOrDefault();

            if (cR_AD_Header == null)
            {
                return View(Auxiliar.ViewsPath.JobPath("unknown"));
            }

            USR_User uSR_User = db.USR_User.Where(x => x.ID == IDTEST).FirstOrDefault();
            USR_CV_Header uSR_CV_Header = db.USR_CV_Header.Where(x => x.IDUser == IDTEST).FirstOrDefault();

            List<long> pos = cR_AD_Header.CR_AD_Detail.Select(x => x.ID).ToList();

            List<long> uSER_CR_Postulate = db.USER_CR_Postulate.Where(x => x.IDUser == IDTEST && pos.Contains(x.IDCRADDetail)).Select(x => x.IDCRADDetail).ToList();
            

            JobsPostulate jobsPostulate = new JobsPostulate();
            jobsPostulate.cR_AD_Header = cR_AD_Header;
            jobsPostulate.uSR_User = uSR_User;
            jobsPostulate.uSR_CV_Header = uSR_CV_Header;
            jobsPostulate.uSER_CR_Postulate = uSER_CR_Postulate;


            return View(jobsPostulate);
        }
       
        [HttpPost]
        public string Postulate(long id)
        {
            try { 
            USER_CR_Postulate uSER_CR_Postulate = new USER_CR_Postulate();
            uSER_CR_Postulate.IDCRADDetail = (long)id;
            uSER_CR_Postulate.IDUser = IDTEST;
            db.USER_CR_Postulate.Add(uSER_CR_Postulate);
            db.SaveChanges();

            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

            return "asd" + id;
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