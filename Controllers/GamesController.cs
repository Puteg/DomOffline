﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DomOffline.DAL;
using DomOffline.Models;
using DomOffline.ModelViews;

namespace DomOffline.Controllers
{
    public class GamesController : Controller
    {
        private DomContext db = new DomContext();

        // GET: Games
        public ActionResult Index()
        {
            return View(db.Games.ToList());
        }

        // GET: Games/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);

            if (game == null)
            {
                return HttpNotFound();
            }

            var payments = db.Payments.Where(c => c.GameId == id && !(new [] {PaymentUse.CashIn, PaymentUse.CashOut }.Contains(c.PaymentUse))).ToList();

            var vm = new GameVm()
            {
                Model = game,

                PlayerList = game.Players.Select(c =>
                    new GamePlayerListItem()
                    {
                        Name = c.Person.Name,
                        Input = string.Join(" + ", c.Payments.Where(s => s.PaymentUse == PaymentUse.CashIn).Select(s => s.Amount.ToString("0.##")).ToList()),
                        Out = string.Join(" + ", c.Payments.Where(s => s.PaymentUse == PaymentUse.CashOut).Select(s => s.Amount.ToString("0.##")).ToList())
                    }).ToList(),

                InputTotalAmount = game.Players.SelectMany(c => c.Payments.Where(s => s.PaymentUse == PaymentUse.CashIn).Select(s => s.Amount)).Sum().ToString("0.##"),
                OutputTotalAmount = game.Players.SelectMany(c => c.Payments.Where(s => s.PaymentUse == PaymentUse.CashOut).Select(s => s.Amount)).Sum().ToString("0.##"),

                RakeList = game.Rakes.Select(c =>
                    new GameRakeListItem()
                    {
                        DateTime = c.DateTime.ToShortTimeString(),
                        Amount = c.Amount.ToString("0.##"),
                        Diler = c.Person.Name
                    }).ToList(),
                RakeTotalAmount = game.Rakes.Sum(c => c.Amount).ToString("0.##"),

                SpendingList = payments.Select(c =>
                    new GameSpendingListItem()
                    {
                        Amount = c.Amount.ToString("0.##"),
                        Use = c.AdditionInfo
                    }).ToList(),
                SpendingTotalAmount = payments.Sum(c => c.Amount).ToString("0.##")
            };

            return View(vm);
        }

        // GET: Games/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Games.Add(game);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(game);
        }

        // GET: Games/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Start,End")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(game);
        }

        // GET: Games/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game game = db.Games.Find(id);
            db.Games.Remove(game);
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
