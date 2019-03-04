using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FeelMiserable.Models;

namespace FeelMiserable.Controllers
{
    public class SlangStoresController : Controller
    {
        private Context db = new Context();

        // GET: SlangStores
        public async Task<ActionResult> Index()
        {
            return View(await db.SlangStores.ToListAsync());
        }

        // GET: SlangStores/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SlangStore slangStore = await db.SlangStores.FindAsync(id);
            if (slangStore == null)
            {
                return HttpNotFound();
            }
            return View(slangStore);
        }

        // GET: SlangStores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SlangStores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] SlangStore slangStore)
        {
            if (ModelState.IsValid)
            {
                db.SlangStores.Add(slangStore);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(slangStore);
        }

        // GET: SlangStores/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SlangStore slangStore = await db.SlangStores.FindAsync(id);
            if (slangStore == null)
            {
                return HttpNotFound();
            }
            return View(slangStore);
        }

        // POST: SlangStores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] SlangStore slangStore)
        {
            if (ModelState.IsValid)
            {
                db.Entry(slangStore).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(slangStore);
        }

        // GET: SlangStores/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SlangStore slangStore = await db.SlangStores.FindAsync(id);
            if (slangStore == null)
            {
                return HttpNotFound();
            }
            return View(slangStore);
        }

        // POST: SlangStores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SlangStore slangStore = await db.SlangStores.FindAsync(id);
            db.SlangStores.Remove(slangStore);
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
