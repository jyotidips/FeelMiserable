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
            if (Session["AddedBy"] == null)
            {
                return RedirectToAction("WhoAreYou");
            }
            return View(await db.SlangStores.OrderBy(c => c.AddedBy).ToListAsync());
        }

        // GET: SlangStores/Details/5
        public async Task<ActionResult> Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (Session["AddedBy"] == null)
            {
                return RedirectToAction("WhoAreYou");
            }

            SlangStore slangStore = await db.SlangStores.FindAsync(id);
            if (slangStore == null)
            {
                return HttpNotFound();
            }
            return View(slangStore);
        }


        public ActionResult WhoAreYou()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> WhoAreYou(SlangStore slangStore)
        {

            if (slangStore.AddedBy != null)
            {

                var addedNew = await db
                    .SlangStores
                    .Where(c => c.AddedBy.ToLower() == slangStore.AddedBy.ToLower())
                    .FirstOrDefaultAsync();



                if (addedNew == null)
                {
                    Session["AddedBy"] = slangStore.AddedBy.ToLower();
                }
                else
                {
                    Session["AddedBy"] = addedNew.AddedBy.ToLower();
                }
            }
            return RedirectToAction("Create");
        }

        // GET: SlangStores/Create
        public ActionResult Create()
        {
            if (Session["AddedBy"] == null)
            {
                return RedirectToAction("WhoAreYou");
            }
            return View();
        }

        // POST: SlangStores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] SlangStore slangStore)
        {
            if (Session["AddedBy"] == null)
            {
                return RedirectToAction("WhoAreYou");
            }

            if (Session["AddedBy"] != null)
            {


                slangStore.AddedBy = Session["AddedBy"].ToString().ToLower();
                db.SlangStores.Add(slangStore);
                await db.SaveChangesAsync();
                TempData["dataAdded"] = "You Slang Is Added!";
                return RedirectToAction("Create");
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

            if (Session["AddedBy"] == null)
            {
                return RedirectToAction("WhoAreYou");
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
            if (Session["AddedBy"] == null)
            {
                return RedirectToAction("WhoAreYou");
            }

            if (Session["AddedBy"] != null)
            {
                slangStore.AddedBy = Session["AddedBy"].ToString().ToLower();
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
