using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DomOffline.DAL;
using DomOffline.Models;

namespace DomOffline.Controllers
{
    public class RakesController : Controller
    {
        private DomContext db = new DomContext();

        // GET: Rakes
        public ActionResult Index()
        {
            var rakes = db.Rakes.Include(r => r.Game).Include(r => r.Person);
            return View(rakes.ToList());
        }

        // GET: Rakes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rake rake = db.Rakes.Find(id);
            if (rake == null)
            {
                return HttpNotFound();
            }
            return View(rake);
        }

        // GET: Rakes/Create
        public ActionResult Create()
        {
            ViewBag.GameId = new SelectList(db.Games, "Id", "Name");
            ViewBag.PersonId = new SelectList(db.Persons, "Id", "Name");
            return View();
        }

        // POST: Rakes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GameId,PersonId,Amount")] Rake rake)
        {
            if (ModelState.IsValid)
            {
                db.Rakes.Add(rake);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GameId = new SelectList(db.Games, "Id", "Name", rake.GameId);
            ViewBag.PersonId = new SelectList(db.Persons, "Id", "Name", rake.PersonId);
            return View(rake);
        }

        // GET: Rakes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rake rake = db.Rakes.Find(id);
            if (rake == null)
            {
                return HttpNotFound();
            }
            ViewBag.GameId = new SelectList(db.Games, "Id", "Name", rake.GameId);
            ViewBag.PersonId = new SelectList(db.Persons, "Id", "Name", rake.PersonId);
            return View(rake);
        }

        // POST: Rakes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GameId,PersonId,Amount,DateTime")] Rake rake)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rake).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GameId = new SelectList(db.Games, "Id", "Name", rake.GameId);
            ViewBag.PersonId = new SelectList(db.Persons, "Id", "Name", rake.PersonId);
            return View(rake);
        }

        // GET: Rakes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rake rake = db.Rakes.Find(id);
            if (rake == null)
            {
                return HttpNotFound();
            }
            return View(rake);
        }

        // POST: Rakes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rake rake = db.Rakes.Find(id);
            db.Rakes.Remove(rake);
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
