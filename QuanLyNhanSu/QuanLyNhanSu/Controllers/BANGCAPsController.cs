using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Controllers
{
    public class BANGCAPsController : Controller
    {
        private Model1 db = new Model1();

        // GET: BANGCAPs
        public ActionResult Index()
        {
            var bANGCAPs = db.BANGCAPs.Include(b => b.NHANVIEN);
            return View(bANGCAPs.ToList());
        }

        // GET: BANGCAPs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BANGCAP bANGCAP = db.BANGCAPs.Find(id);
            if (bANGCAP == null)
            {
                return HttpNotFound();
            }
            return View(bANGCAP);
        }

        // GET: BANGCAPs/Create
        public ActionResult Create()
        {
            ViewBag.MANV = new SelectList(db.NHANVIENs, "MANV", "HOTEN");
            return View();
        }

        // POST: BANGCAPs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MABC,MANV,TENBC,LOAIBC,NGAYCAP,DVCAP")] BANGCAP bANGCAP)
        {
            if (ModelState.IsValid)
            {
                db.BANGCAPs.Add(bANGCAP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MANV = new SelectList(db.NHANVIENs, "MANV", "HOTEN", bANGCAP.MANV);
            return View(bANGCAP);
        }

        // GET: BANGCAPs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BANGCAP bANGCAP = db.BANGCAPs.Find(id);
            if (bANGCAP == null)
            {
                return HttpNotFound();
            }
            ViewBag.MANV = new SelectList(db.NHANVIENs, "MANV", "HOTEN", bANGCAP.MANV);
            return View(bANGCAP);
        }

        // POST: BANGCAPs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MABC,MANV,TENBC,LOAIBC,NGAYCAP,DVCAP")] BANGCAP bANGCAP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bANGCAP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MANV = new SelectList(db.NHANVIENs, "MANV", "HOTEN", bANGCAP.MANV);
            return View(bANGCAP);
        }

        // GET: BANGCAPs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BANGCAP bANGCAP = db.BANGCAPs.Find(id);
            if (bANGCAP == null)
            {
                return HttpNotFound();
            }
            return View(bANGCAP);
        }

        // POST: BANGCAPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BANGCAP bANGCAP = db.BANGCAPs.Find(id);
            db.BANGCAPs.Remove(bANGCAP);
            db.SaveChanges();
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
