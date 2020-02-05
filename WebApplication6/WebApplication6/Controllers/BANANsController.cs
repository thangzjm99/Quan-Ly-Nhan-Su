using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication6;

namespace WebApplication6.Controllers
{
    public class BANANsController : Controller
    {
        private Model1 db = new Model1();

        // GET: BANANs
        public ActionResult Index()
        {
            var bANANs = db.BANANs.Include(b => b.NHANVIEN);
            return View(bANANs.ToList());
        }

        // GET: BANANs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BANAN bANAN = db.BANANs.Find(id);
            if (bANAN == null)
            {
                return HttpNotFound();
            }
            return View(bANAN);
        }

        // GET: BANANs/Create
        public ActionResult Create()
        {
            ViewBag.ID_MANHANVIEN = new SelectList(db.NHANVIENs, "MANHANVIEN", "TENNHANVIEN");
            return View();
        }

        // POST: BANANs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MABAN,ID_MANHANVIEN,LOAIBAN,TINHTRANG")] BANAN bANAN)
        {
            if (ModelState.IsValid)
            {
                db.BANANs.Add(bANAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_MANHANVIEN = new SelectList(db.NHANVIENs, "MANHANVIEN", "TENNHANVIEN", bANAN.ID_MANHANVIEN);
            return View(bANAN);
        }

        // GET: BANANs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BANAN bANAN = db.BANANs.Find(id);
            if (bANAN == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_MANHANVIEN = new SelectList(db.NHANVIENs, "MANHANVIEN", "TENNHANVIEN", bANAN.ID_MANHANVIEN);
            return View(bANAN);
        }

        // POST: BANANs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MABAN,ID_MANHANVIEN,LOAIBAN,TINHTRANG")] BANAN bANAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bANAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_MANHANVIEN = new SelectList(db.NHANVIENs, "MANHANVIEN", "TENNHANVIEN", bANAN.ID_MANHANVIEN);
            return View(bANAN);
        }

        // GET: BANANs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BANAN bANAN = db.BANANs.Find(id);
            if (bANAN == null)
            {
                return HttpNotFound();
            }
            return View(bANAN);
        }

        // POST: BANANs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BANAN bANAN = db.BANANs.Find(id);
            db.BANANs.Remove(bANAN);
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
