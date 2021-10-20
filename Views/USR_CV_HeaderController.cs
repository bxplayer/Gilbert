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

namespace Gilbert.Views
{
    public class USR_CV_HeaderController : Controller
    {
        private GilbertEntities db = new GilbertEntities();

        // GET: USR_CV_Header
        public async Task<ActionResult> Index()
        {
            var uSR_CV_Header = db.USR_CV_Header.Include(u => u.MD_State).Include(u => u.USR_User);
            return View(await uSR_CV_Header.ToListAsync());
        }

        // GET: USR_CV_Header/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USR_CV_Header uSR_CV_Header = await db.USR_CV_Header.FindAsync(id);
            if (uSR_CV_Header == null)
            {
                return HttpNotFound();
            }
            return View(uSR_CV_Header);
        }

        // GET: USR_CV_Header/Create
        public ActionResult Create()
        {
            ViewBag.IDState = new SelectList(db.MD_State, "ID", "SDescrip");
            ViewBag.IDUser = new SelectList(db.USR_User, "ID", "Email");
            return View();
        }

        // POST: USR_CV_Header/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,IDUser,Street,StreetNumber,PostCode,IDState,IDNationality,Birthdate,Age,IDStatus")] USR_CV_Header uSR_CV_Header)
        {
            if (ModelState.IsValid)
            {
                db.USR_CV_Header.Add(uSR_CV_Header);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IDState = new SelectList(db.MD_State, "ID", "SDescrip", uSR_CV_Header.IDState);
            ViewBag.IDUser = new SelectList(db.USR_User, "ID", "Email", uSR_CV_Header.IDUser);
            return View(uSR_CV_Header);
        }

        // GET: USR_CV_Header/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USR_CV_Header uSR_CV_Header = await db.USR_CV_Header.FindAsync(id);
            if (uSR_CV_Header == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDState = new SelectList(db.MD_State, "ID", "SDescrip", uSR_CV_Header.IDState);
            ViewBag.IDUser = new SelectList(db.USR_User, "ID", "Email", uSR_CV_Header.IDUser);
            return View(uSR_CV_Header);
        }

        // POST: USR_CV_Header/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,IDUser,Street,StreetNumber,PostCode,IDState,IDNationality,Birthdate,Age,IDStatus")] USR_CV_Header uSR_CV_Header)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSR_CV_Header).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IDState = new SelectList(db.MD_State, "ID", "SDescrip", uSR_CV_Header.IDState);
            ViewBag.IDUser = new SelectList(db.USR_User, "ID", "Email", uSR_CV_Header.IDUser);
            return View(uSR_CV_Header);
        }

        // GET: USR_CV_Header/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USR_CV_Header uSR_CV_Header = await db.USR_CV_Header.FindAsync(id);
            if (uSR_CV_Header == null)
            {
                return HttpNotFound();
            }
            return View(uSR_CV_Header);
        }

        // POST: USR_CV_Header/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            USR_CV_Header uSR_CV_Header = await db.USR_CV_Header.FindAsync(id);
            db.USR_CV_Header.Remove(uSR_CV_Header);
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
