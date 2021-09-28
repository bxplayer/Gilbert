using Gilbert.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Gilbert.Controllers.Company
{
    public class EmployController : Controller
    {
        private GilbertEntities db = new GilbertEntities();        

        // GET: Employ
        public async Task<ActionResult> Index()
        {
            var cR_AD_Header = db.CR_AD_Header.Include(c => c.CR_User);
            return View(Auxiliar.ViewsPath.CompanyPath("Index"), await cR_AD_Header.ToListAsync());            
        }


        public ActionResult Create()
        {
            ViewBag.IDPosition = new SelectList(db.MD_Position.Where(x => x.IDStatus == 1), "ID", "LDescrip");
            ViewBag.IDEducation = new SelectList(db.MD_EducationRequired.Where(x => x.IDStatus == 1), "ID", "LDescrip");
            ViewBag.IDExperience = new SelectList(db.MD_ExperienceRequired.Where(x => x.IDStatus == 1), "ID", "LDescrip");
            return View(Auxiliar.ViewsPath.CompanyPath("Create"));
        }
        
    }
}