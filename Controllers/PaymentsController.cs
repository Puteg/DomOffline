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
    public class PaymentsController : Controller
    {
        private DomContext db = new DomContext();

        // GET: Payments
        public ActionResult Index()
        {
            var payments = db.Payments.Include(p => p.Game).Include(p => p.Player).Include(p => p.Type);
            return View(payments.ToList());
        }

        // GET: Payments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // GET: Payments/Create
        public ActionResult Create()
        {
            ViewBag.GameId = new SelectList(db.Games, "Id", "Name");
            ViewBag.PlayerId = new SelectList(db.Players.Select(c => new SelectListItem { Text = c.Person.Name, Value = c.Id.ToString() }), "Value", "Text");
            ViewBag.TypeId = new SelectList(db.PaymentTypes, "Id", "Name");
            return View();
        }


        public PartialViewResult CreateParital(int gameId)
        {
            ViewBag.GameId = new SelectList(db.Games, "Id", "Name");
            ViewBag.PlayerId = new SelectList(db.Players.Where(c => c.GameId == gameId).Select(c => new SelectListItem { Text = c.Person.Name, Value = c.Id.ToString() }), "Value", "Text");
            ViewBag.TypeId = new SelectList(db.PaymentTypes, "Id", "Name");
            return PartialView(new Payment() {GameId = gameId});
        }


        public PartialViewResult RebuyParital(int gameId)
        {
            ViewBag.GameId = new SelectList(db.Games, "Id", "Name");
            ViewBag.PlayerId = new SelectList(db.Players.Where(c => c.GameId == gameId).Select(c => new SelectListItem { Text = c.Person.Name, Value = c.Id.ToString() }), "Value", "Text");
            ViewBag.TypeId = new SelectList(db.PaymentTypes, "Id", "Name");
            return PartialView("PaymentUseParital", new Payment() { GameId = gameId, PaymentUse = PaymentUse.CashIn});
        }

        public PartialViewResult SeatOutParital(int gameId)
        {
            ViewBag.GameId = new SelectList(db.Games, "Id", "Name");
            ViewBag.PlayerId = new SelectList(db.Players.Where(c => c.GameId == gameId).Select(c => new SelectListItem { Text = c.Person.Name, Value = c.Id.ToString() }), "Value", "Text");
            ViewBag.TypeId = new SelectList(db.PaymentTypes, "Id", "Name");
            return PartialView("PaymentUseParital", new Payment() { GameId = gameId, PaymentUse = PaymentUse.CashOut});
        }

        // POST: Payments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TypeId,PlayerId,GameId,PaymentUse,Amount,AdditionInfo")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Payments.Add(payment);
                db.SaveChanges();

                if (Request.UrlReferrer != null && Request.UrlReferrer != Request.Url)
                    return Redirect(Request.UrlReferrer.ToString());

                return RedirectToAction("Index");
            }

            ViewBag.GameId = new SelectList(db.Games, "Id", "Name", payment.GameId);
            ViewBag.PlayerId = new SelectList(db.Players.Select(c => new SelectListItem{ Text = c.Person.Name, Value = c.Id.ToString()}));
            ViewBag.TypeId = new SelectList(db.PaymentTypes, "Id", "Name", payment.TypeId);
            return View(payment);
        }

        // GET: Payments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            ViewBag.GameId = new SelectList(db.Games, "Id", "Name", payment.GameId);
            ViewBag.PlayerId = new SelectList(db.Players, "Id", "Id", payment.PlayerId);
            ViewBag.TypeId = new SelectList(db.PaymentTypes, "Id", "Name", payment.TypeId);
            return View(payment);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TypeId,PlayerId,GameId,PaymentUse,DateTime,Amount,AdditionInfo")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GameId = new SelectList(db.Games, "Id", "Name", payment.GameId);
            ViewBag.PlayerId = new SelectList(db.Players, "Id", "Id", payment.PlayerId);
            ViewBag.TypeId = new SelectList(db.PaymentTypes, "Id", "Name", payment.TypeId);
            return View(payment);
        }

        // GET: Payments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Payment payment = db.Payments.Find(id);
            db.Payments.Remove(payment);
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
