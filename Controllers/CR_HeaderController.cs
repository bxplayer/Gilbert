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

namespace Gilbert.Controllers
{
    public class CR_HeaderController : Controller
    {
        private GilbertEntities db = new GilbertEntities();

        // GET: CR_Header
        public async Task<ActionResult> Index()
        {
            var cR_AD_Header = db.CR_AD_Header.Include(c => c.CR_User);
            return View(await cR_AD_Header.ToListAsync());
        }

        // GET: CR_Header/Details/5
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
            return View(cR_AD_Header);
        }

        // GET: CR_Header/Create
        public ActionResult Create()
        {
            ViewBag.IDUserCreator = new SelectList(db.CR_User, "ID", "Email");
            return View();
        }

        // POST: CR_Header/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,IDUserCreator,CreationDate,StartDate,FinishDate,SDescrip,LDescrip,IDStatus")] CR_AD_Header cR_AD_Header)
        {
            if (ModelState.IsValid)
            {
                db.CR_AD_Header.Add(cR_AD_Header);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IDUserCreator = new SelectList(db.CR_User, "ID", "Email", cR_AD_Header.IDUserCreator);
            return View(cR_AD_Header);
        }

        // GET: CR_Header/Edit/5
        public async Task<ActionResult> Edit(long? id)
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
            ViewBag.IDUserCreator = new SelectList(db.CR_User, "ID", "Email", cR_AD_Header.IDUserCreator);
            return View(cR_AD_Header);
        }

        // POST: CR_Header/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,IDUserCreator,CreationDate,StartDate,FinishDate,SDescrip,LDescrip,IDStatus")] CR_AD_Header cR_AD_Header)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cR_AD_Header).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IDUserCreator = new SelectList(db.CR_User, "ID", "Email", cR_AD_Header.IDUserCreator);
            return View(cR_AD_Header);
        }

        // GET: CR_Header/Delete/5
        public async Task<ActionResult> Delete(long? id)
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
            return View(cR_AD_Header);
        }

        // POST: CR_Header/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            CR_AD_Header cR_AD_Header = await db.CR_AD_Header.FindAsync(id);
            db.CR_AD_Header.Remove(cR_AD_Header);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
