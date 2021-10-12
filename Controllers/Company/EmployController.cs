using Gilbert.Models;
using Newtonsoft.Json;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Gilbert.Controllers.Company
{
    public class EmployController : Controller
    {
        private GilbertEntities db = new GilbertEntities();        

        // GET: Employ
        public ActionResult Index()
        {            
           var vw_cR_HeaderPostulate = db.vw_CR_HeaderPostulate.Where(x => x.IDCompany == 1);
           return View(Auxiliar.ViewsPath.CompanyPath("Index"), vw_cR_HeaderPostulate.ToList());            
        }


        public ActionResult Create()
        {

            ViewBag.IDPosition = new SelectList(db.MD_Position.Where(x => x.IDStatus == 1), "ID", "LDescrip", 0);
            ViewBag.IDEducation = new SelectList(db.MD_EducationRequired.Where(x => x.IDStatus == 1), "ID", "LDescrip");
            ViewBag.IDExperience = new SelectList(db.MD_ExperienceRequired.Where(x => x.IDStatus == 1), "ID", "LDescrip");
            return View(Auxiliar.ViewsPath.CompanyPath("Create"));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "StartDate,FinishDate,SDescrip,LDescrip,Details")] CR_AD_Header cR_AD_Header)
        {
            if (ModelState.IsValid)
            {
                DateTime create_at = DateTime.Now;
                List<CR_AD_Detail> parseDataDetail = JsonConvert.DeserializeObject<List<CR_AD_Detail>>(cR_AD_Header.Details);

                if (parseDataDetail.Count == 0)
                {
                    ModelState.AddModelError("Details", "La fecha de inicio no puede ser mayor a la de terminado");
                    return View(Auxiliar.ViewsPath.CompanyPath("Create"), cR_AD_Header);
                }

                foreach (CR_AD_Detail Detail in parseDataDetail)
                {
                    cR_AD_Header.CR_AD_Detail.Add(Detail);
                }                               
                                
                cR_AD_Header.CreationDate = create_at;
                /*Cambiar*/
                cR_AD_Header.IDUserCreator = 1;
                cR_AD_Header.IDStatus = 1;

                cR_AD_Header.Unique_ID = Guid.NewGuid();
                db.CR_AD_Header.Add(cR_AD_Header);
                await db.SaveChangesAsync();


                string txtQRCode = new Uri(HttpContext.Request.Url.Authority).OriginalString + "/Job/" + cR_AD_Header.Unique_ID;
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(txtQRCode, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                //System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                //imgBarCode.Height = 150;
                //imgBarCode.Width = 150; 
                using (Bitmap bitMap = qrCode.GetGraphic(20))
                {
                    bitMap.Save(Server.MapPath("~/Images/QR/") + cR_AD_Header.Unique_ID + ".png", System.Drawing.Imaging.ImageFormat.Png);   
                 
                }

                return RedirectToAction("Index");
            }

            return View(Auxiliar.ViewsPath.CompanyPath("Create"), cR_AD_Header);
        }



        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CR_AD_Header cR_AD_Header = await db.CR_AD_Header.FindAsync(id);
            if (cR_AD_Header == null)
            {
                return HttpNotFound();
            }            

            return View(Auxiliar.ViewsPath.CompanyPath("Details"),cR_AD_Header);
        }

        public ActionResult Download(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CR_AD_Header cR_AD_Header = db.CR_AD_Header.Find(id);
            if (cR_AD_Header == null)
            {
                return HttpNotFound();
            }

            return File(Server.MapPath("~/Images/QR/") + cR_AD_Header.Unique_ID + ".png", "image/png" , Auxiliar.Auxiliar.GenerateSlug(cR_AD_Header.SDescrip) + ".png");            
        }

    }


}