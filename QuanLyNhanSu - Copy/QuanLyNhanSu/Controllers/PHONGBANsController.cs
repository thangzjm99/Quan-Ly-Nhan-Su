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
    public class PHONGBANsController : Controller
    {
        private Model1 db = new Model1();

        // GET: PHONGBANs
        public ActionResult Index(string searchBy,string search,string sortOrder)
        {
            ViewBag.TenpbSortParm = sortOrder == "tenpb" ? "tenpb_desc" : "tenpb";
            ViewBag.TruongpbSortParm = sortOrder == "truongpb" ? "truongpb_desc" : "truongpb";
            var pHONGBANs1 = db.PHONGBANs.AsQueryable();
            if (!String.IsNullOrEmpty(search))
            {
                if (searchBy == "TENPB")
                {
                    return View(db.PHONGBANs.Where(b => b.TENPB.Contains(search) || search == null).ToList());

                }
                else if (searchBy == "TRGPB")
                {
                    return View(db.PHONGBANs.Where(b => b.TRGPB.Contains(search) || search == null).ToList());

                }
                else return View(pHONGBANs1.ToList());
            }
            switch (sortOrder)
            {
                case "tenpb_desc":
                    pHONGBANs1 = pHONGBANs1.OrderByDescending(s => s.TENPB);
                    break;
                case "truongpb":
                    pHONGBANs1 = pHONGBANs1.OrderBy(s => s.TRGPB);
                    break;
                case "truongpb_desc":
                    pHONGBANs1 = pHONGBANs1.OrderByDescending(s => s.TRGPB);
                    break;
                default:
                    pHONGBANs1 = pHONGBANs1.OrderBy(s => s.TENPB);
                    break;
            }
            return View(pHONGBANs1.ToList());
        }

        // GET: PHONGBANs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHONGBAN pHONGBAN = db.PHONGBANs.Find(id);
            if (pHONGBAN == null)
            {
                return HttpNotFound();
            }
            return View(pHONGBAN);
        }

        // GET: PHONGBANs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PHONGBANs/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAPB,TENPB,TRGPB")] PHONGBAN pHONGBAN)
        {
            if (ModelState.IsValid)
            {
                db.PHONGBANs.Add(pHONGBAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pHONGBAN);
        }

        // GET: PHONGBANs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHONGBAN pHONGBAN = db.PHONGBANs.Find(id);
            if (pHONGBAN == null)
            {
                return HttpNotFound();
            }
            return View(pHONGBAN);
        }

        // POST: PHONGBANs/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAPB,TENPB,TRGPB")] PHONGBAN pHONGBAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHONGBAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pHONGBAN);
        }

        // GET: PHONGBANs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHONGBAN pHONGBAN = db.PHONGBANs.Find(id);
            if (pHONGBAN == null)
            {
                return HttpNotFound();
            }
            return View(pHONGBAN);
        }

        // POST: PHONGBANs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PHONGBAN pHONGBAN = db.PHONGBANs.Find(id);
            db.PHONGBANs.Remove(pHONGBAN);
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
