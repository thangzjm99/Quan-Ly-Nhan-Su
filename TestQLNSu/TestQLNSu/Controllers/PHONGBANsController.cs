using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestQLNSu;

namespace TestQLNSu.Controllers
{
    public class PHONGBANsController : Controller
    {
        private Model1 db = new Model1();

        // GET: PHONGBANs
        public async Task<ActionResult> Index()
        {
            return View(await db.PHONGBANs.ToListAsync());
        }

        // GET: PHONGBANs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHONGBAN pHONGBAN = await db.PHONGBANs.FindAsync(id);
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MAPB,TENPB,TRGPB")] PHONGBAN pHONGBAN)
        {
            if (ModelState.IsValid)
            {
                db.PHONGBANs.Add(pHONGBAN);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(pHONGBAN);
        }

        // GET: PHONGBANs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHONGBAN pHONGBAN = await db.PHONGBANs.FindAsync(id);
            if (pHONGBAN == null)
            {
                return HttpNotFound();
            }
            return View(pHONGBAN);
        }

        // POST: PHONGBANs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MAPB,TENPB,TRGPB")] PHONGBAN pHONGBAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHONGBAN).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pHONGBAN);
        }

        // GET: PHONGBANs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHONGBAN pHONGBAN = await db.PHONGBANs.FindAsync(id);
            if (pHONGBAN == null)
            {
                return HttpNotFound();
            }
            return View(pHONGBAN);
        }

        // POST: PHONGBANs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PHONGBAN pHONGBAN = await db.PHONGBANs.FindAsync(id);
            db.PHONGBANs.Remove(pHONGBAN);
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
