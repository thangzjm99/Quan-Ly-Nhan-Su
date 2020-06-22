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

       
        public ActionResult Index(string searchBy, string search,string sortOrder)
        {
            ViewBag.TenbcSortParm = sortOrder == "tenbc" ? "tenbc_desc" : "tenbc";
            ViewBag.LoaibcSortParm = sortOrder == "loaibc" ? "loaibc_desc" : "loaibc";
            ViewBag.DvcapSortParm = sortOrder == "dvcap" ? "dvcap_desc" : "dvcap";
            ViewBag.TennvSortParm = sortOrder == "tennv" ? "tennv_desc" : "tennv";
            ViewBag.NgaycapSortParm = sortOrder == "ngaycap" ? "ngaycap_desc" : "ngaycap";
            var bANGCAPs1 = db.BANGCAPs.AsQueryable();
            if (!String.IsNullOrEmpty(search))
            {
                if (searchBy == "TENBC")
                {
                    return View(db.BANGCAPs.Where(b => b.TENBC.Contains(search) || search == null).ToList());

                }
                else if (searchBy == "LOAIBC")
                {
                    return View(db.BANGCAPs.Where(b => b.LOAIBC.Contains(search) || search == null).ToList());
                }
                else if (searchBy == "DVCAP")
                {
                    return View(db.BANGCAPs.Where(b => b.DVCAP.Contains(search) || search == null).ToList());
                }
                else if (searchBy == "TENNV")
                {
                    return View(db.BANGCAPs.Where(b => b.NHANVIEN.HOTEN.Contains(search) || search == null).ToList());
                }
                else if (searchBy == "NGAYCAP")
                {
                    return View(db.BANGCAPs.Where(b => b.NGAYCAP.ToString().Contains(search) || search == null).ToList());
                }
                else
                {
                    return View(bANGCAPs1.ToList());
                }
            }


            switch (sortOrder)
            {
                case "tenbc_desc":
                    bANGCAPs1 = bANGCAPs1.OrderByDescending(s => s.TENBC);
                    break;
                case "loaibc":
                    bANGCAPs1 = bANGCAPs1.OrderBy(s => s.LOAIBC);
                    break;
                case "loaibc_desc":
                    bANGCAPs1 = bANGCAPs1.OrderByDescending(s => s.LOAIBC);
                    break;
                case "dvcap":
                    bANGCAPs1 = bANGCAPs1.OrderBy(s => s.DVCAP);
                    break;
                case "dvcap_desc":
                    bANGCAPs1 = bANGCAPs1.OrderByDescending(s => s.DVCAP);
                    break;
                case "tennv":
                    bANGCAPs1 = bANGCAPs1.OrderBy(s => s.NHANVIEN.HOTEN);
                    break;
                case "tennv_desc":
                    bANGCAPs1 = bANGCAPs1.OrderByDescending(s => s.NHANVIEN.HOTEN);
                    break;
                case "ngaycap":
                    bANGCAPs1 = bANGCAPs1.OrderBy(s => s.NGAYCAP);
                    break;
                case "ngaycap_desc":
                    bANGCAPs1 = bANGCAPs1.OrderByDescending(s => s.NGAYCAP);
                    break;
                default:
                    bANGCAPs1 = bANGCAPs1.OrderBy(s => s.TENBC);
                    break;
            }
            return View(bANGCAPs1.ToList());

           
            //ViewBag.TenbcSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            
        }

        public ActionResult Search(string searchBy, string search)
        {
            var bANGCAPs = db.BANGCAPs.Include(b => b.NHANVIEN);

            if (searchBy == "TENBC")
            {
                return View(db.BANGCAPs.Where(b => b.TENBC.Contains(search) || search == null).ToList());

            }
            else if (searchBy == "LOAIBC")
            {
                return View(db.BANGCAPs.Where(b => b.LOAIBC.Contains(search) || search == null).ToList());
            }
            else if (searchBy == "DVCAP")
            {
                return View(db.BANGCAPs.Where(b => b.DVCAP.Contains(search) || search == null).ToList());
            }
            else
            {
                return View(bANGCAPs.ToList());
            }

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
