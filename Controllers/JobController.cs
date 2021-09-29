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

            }

            CR_AD_Header cR_AD_Header = db.CR_AD_Header.Where(x => x.Unique_ID.ToString() == uniqueID).FirstOrDefault();
            return View(cR_AD_Header);
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