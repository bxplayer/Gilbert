using Gilbert.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Gilbert.Controllers
{
    public class JobController : Controller
    {
        private GilbertEntities db = new GilbertEntities();
        // GET: Job

        //[Route("Job/{uniqueID:string?}")]

       
        public ActionResult Index(string uniqueID)
        {
            if (String.IsNullOrEmpty(uniqueID))
            {
                return View(Auxiliar.ViewsPath.JobPath("unknown"));
            }

            CR_AD_Header cR_AD_Header = db.CR_AD_Header.Where(x => x.Unique_ID.ToString() == uniqueID).FirstOrDefault();

            if (cR_AD_Header == null)
            {
                return View(Auxiliar.ViewsPath.JobPath("unknown"));
            }

            USR_User uSR_User = db.USR_User.Where(x => x.ID == 2).FirstOrDefault();

            JobsPostulate jobsPostulate = new JobsPostulate();
            jobsPostulate.cR_AD_Header = cR_AD_Header;
            jobsPostulate.uSR_User = uSR_User;


            return View(jobsPostulate);
        }
       

        private void GetUserData()
        {

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