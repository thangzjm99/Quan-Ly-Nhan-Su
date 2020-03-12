using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLNSfake.Models;

namespace QLNSfake.Controllers
{
    public class NHANVIENsController : Controller
    {
        private Model1 db = new Model1();

        // GET: NHANVIENs
        public async Task<ActionResult> Index()
        {
            var nHANVIENs = db.NHANVIENs.Include(n => n.PHONGBAN);
            return View(await nHANVIENs.ToListAsync());
        }

        // GET: NHANVIENs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = await db.NHANVIENs.FindAsync(id);
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MANV,HOTEN,DIACHI,SDT,NGAYSINH,CMND,GIOITINH,QUEQUAN,DANTOC,MAPB,SOSOBH,CHUCVU")] NHANVIEN nHANVIEN)
        {
            if (ModelState.IsValid)
            {
                db.NHANVIENs.Add(nHANVIEN);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MAPB = new SelectList(db.PHONGBANs, "MAPB", "TENPB", nHANVIEN.MAPB);
            return View(nHANVIEN);
        }

        // GET: NHANVIENs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = await db.NHANVIENs.FindAsync(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.MAPB = new SelectList(db.PHONGBANs, "MAPB", "TENPB", nHANVIEN.MAPB);
            return View(nHANVIEN);
        }

        // POST: NHANVIENs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MANV,HOTEN,DIACHI,SDT,NGAYSINH,CMND,GIOITINH,QUEQUAN,DANTOC,MAPB,SOSOBH,CHUCVU")] NHANVIEN nHANVIEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nHANVIEN).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MAPB = new SelectList(db.PHONGBANs, "MAPB", "TENPB", nHANVIEN.MAPB);
            return View(nHANVIEN);
        }

        // GET: NHANVIENs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = await db.NHANVIENs.FindAsync(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // POST: NHANVIENs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            NHANVIEN nHANVIEN = await db.NHANVIENs.FindAsync(id);
            db.NHANVIENs.Remove(nHANVIEN);
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
