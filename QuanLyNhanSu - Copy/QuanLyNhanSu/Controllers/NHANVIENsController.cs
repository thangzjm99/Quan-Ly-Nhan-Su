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
        public ActionResult Index(string searchBy,string search,string sortOrder,string searchTop)
        {

            ViewBag.TennvSortParm = sortOrder == "hoten" ? "hoten_desc" : "hoten";
            ViewBag.DiachiSortParm = sortOrder == "diachi" ? "diachi_desc" : "diachi";
            ViewBag.SdtSortParm = sortOrder == "sdt" ? "sdt_desc" : "sdt";
            ViewBag.NgaysinhSortParm = sortOrder == "ngaysinh" ? "ngaysinh_desc" : "ngaysinh";
            ViewBag.CmndSortParm = sortOrder == "cmnd" ? "cmnd_desc" : "cmnd";
            ViewBag.GioitinhSortParm = sortOrder == "gioitinh" ? "gioitinh_desc" : "gioitinh";
            ViewBag.QuequanSortParm = sortOrder == "quequan" ? "quequan_desc" : "quequan";
            ViewBag.DantocSortParm = sortOrder == "dantoc" ? "dantoc_desc" : "dantoc";
            ViewBag.SobhSortParm = sortOrder == "sobh" ? "sobh_desc" : "sobh";
            ViewBag.ChucvuSortParm = sortOrder == "chucvu" ? "chucvu_desc" : "chucvu";
            ViewBag.TenpbSortParm = sortOrder == "tenpb" ? "tenpb_desc" : "tenpb";
            

            var nHANVIENs1 = db.NHANVIENs.AsQueryable();

            if (!String.IsNullOrEmpty(search))
            {
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
                else return View(nHANVIENs1.ToList());
            }
            switch (sortOrder)
            {
                case "hoten_desc":
                    nHANVIENs1 = nHANVIENs1.OrderByDescending(s => s.HOTEN);
                    break;
                case "diachi":
                    nHANVIENs1 = nHANVIENs1.OrderBy(s => s.DIACHI);
                    break;
                case "diachi_desc":
                    nHANVIENs1 = nHANVIENs1.OrderByDescending(s => s.DIACHI);
                    break;
                case "sdt":
                    nHANVIENs1 = nHANVIENs1.OrderBy(s => s.SDT);
                    break;
                case "sdt_desc":
                    nHANVIENs1 = nHANVIENs1.OrderByDescending(s => s.SDT);
                    break;
                case "ngaysinh":
                    nHANVIENs1 = nHANVIENs1.OrderBy(s => s.NGAYSINH);
                    break;
                case "ngaysinh_desc":
                    nHANVIENs1 = nHANVIENs1.OrderByDescending(s => s.NGAYSINH);
                    break;
                case "cmnd":
                    nHANVIENs1 = nHANVIENs1.OrderBy(s => s.CMND);
                    break;
                case "cmnd_desc":
                    nHANVIENs1 = nHANVIENs1.OrderByDescending(s => s.CMND);
                    break;
                case "gioitinh":
                    nHANVIENs1 = nHANVIENs1.OrderBy(s => s.GIOITINH);
                    break;
                case "gioitinh_desc":
                    nHANVIENs1 = nHANVIENs1.OrderByDescending(s => s.GIOITINH);
                    break;
                case "quequan":
                    nHANVIENs1 = nHANVIENs1.OrderBy(s => s.QUEQUAN);
                    break;
                case "quequan_desc":
                    nHANVIENs1 = nHANVIENs1.OrderByDescending(s => s.QUEQUAN);
                    break;
                case "dantoc":
                    nHANVIENs1 = nHANVIENs1.OrderBy(s => s.DANTOC);
                    break;
                case "dantoc_desc":
                    nHANVIENs1 = nHANVIENs1.OrderByDescending(s => s.DANTOC);
                    break;
                case "sobh":
                    nHANVIENs1 = nHANVIENs1.OrderBy(s => s.SOSOBH);
                    break;
                case "sobh_desc":
                    nHANVIENs1 = nHANVIENs1.OrderByDescending(s => s.SOSOBH);
                    break;
                case "chucvu":
                    nHANVIENs1 = nHANVIENs1.OrderBy(s => s.CHUCVU);
                    break;
                case "chucvu_desc":
                    nHANVIENs1 = nHANVIENs1.OrderByDescending(s => s.CHUCVU);
                    break;
                case "tenpb":
                    nHANVIENs1 = nHANVIENs1.OrderBy(s => s.PHONGBAN.TENPB);
                    break;
                case "tenpb_desc":
                    nHANVIENs1 = nHANVIENs1.OrderByDescending(s => s.PHONGBAN.TENPB);
                    break;
                default:
                    nHANVIENs1 = nHANVIENs1.OrderBy(s => s.HOTEN);
                    break;
            }
            return View(nHANVIENs1.ToList());


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
