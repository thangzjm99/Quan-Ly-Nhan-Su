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
    public class NHANVIENsController : Controller
    {
        private Model1 db = new Model1();

        // GET: NHANVIENs
        public ActionResult Index(string searchBy,string search)
        {
            var nHANVIENs = db.NHANVIENs.Include(n => n.PHONGBAN);
            if (searchBy == "HOTEN")
            {
                return View(db.NHANVIENs.Where(b => b.HOTEN.Contains(search) || search == null).ToList());

            }
            else if (searchBy == "DIACHI")
            {
                return View(db.NHANVIENs.Where(b => b.DIACHI.Contains(search) || search == null).ToList());
            }
            else if (searchBy == "SDT")
            {
                return View(db.NHANVIENs.Where(b => b.SDT.ToString().Contains(search) || search == null).ToList());
            }
            else if (searchBy == "NGAYSINH")
            {
                return View(db.NHANVIENs.Where(b => b.NGAYSINH.ToString().Contains(search) || search == null).ToList());
            }
            else if (searchBy == "CMND")
            {
                return View(db.NHANVIENs.Where(b => b.CMND.ToString().Contains(search) || search == null).ToList());
            }
            else if (searchBy == "GIOITINH")
            {
                return View(db.NHANVIENs.Where(b => b.GIOITINH.Contains(search) || search == null).ToList());
            }
            else if (searchBy == "QUEQUAN")
            {
                return View(db.NHANVIENs.Where(b => b.QUEQUAN.Contains(search) || search == null).ToList());
            }
            else if (searchBy == "DANTOC")
            {
                return View(db.NHANVIENs.Where(b => b.DANTOC.Contains(search) || search == null).ToList());
            }
            else if (searchBy == "SOSOBH")
            {
                return View(db.NHANVIENs.Where(b => b.SOSOBH.ToString().Contains(search) || search == null).ToList());
            }
            else return View(nHANVIENs.ToList());
        }

        // GET: NHANVIENs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // GET: NHANVIENs/Create
        public ActionResult Create()
        {
            ViewBag.MAPB = new SelectList(db.PHONGBANs, "MAPB", "TENPB");
            return View();
        }

        // POST: NHANVIENs/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MANV,HOTEN,DIACHI,SDT,NGAYSINH,CMND,GIOITINH,QUEQUAN,DANTOC,MAPB,SOSOBH,CHUCVU")] NHANVIEN nHANVIEN)
        {
            if (ModelState.IsValid)
            {
                db.NHANVIENs.Add(nHANVIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MAPB = new SelectList(db.PHONGBANs, "MAPB", "TENPB", nHANVIEN.MAPB);
            return View(nHANVIEN);
        }

        // GET: NHANVIENs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.MAPB = new SelectList(db.PHONGBANs, "MAPB", "TENPB", nHANVIEN.MAPB);
            return View(nHANVIEN);
        }

        // POST: NHANVIENs/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MANV,HOTEN,DIACHI,SDT,NGAYSINH,CMND,GIOITINH,QUEQUAN,DANTOC,MAPB,SOSOBH,CHUCVU")] NHANVIEN nHANVIEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nHANVIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MAPB = new SelectList(db.PHONGBANs, "MAPB", "TENPB", nHANVIEN.MAPB);
            return View(nHANVIEN);
        }

        // GET: NHANVIENs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // POST: NHANVIENs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            db.NHANVIENs.Remove(nHANVIEN);
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
