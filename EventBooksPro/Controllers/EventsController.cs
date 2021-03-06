﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EventBooksPro.Models;
using Microsoft.AspNet.Identity;

namespace EventBooksPro.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Events
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var events = db.Events.Where(e => e.ApplicationUserId == userId);

            return View(events.ToList());
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            var userId = User.Identity.GetUserId();
            var events = db.Events.Where(e => e.ApplicationUserId == userId && e.Id == id).FirstOrDefault();
            return View(events);
        }

        public ActionResult Search(string searchString)
        {
            var userId = User.Identity.GetUserId();
            var events = db.Events.Where(e => e.ApplicationUserId == userId);

            if (!String.IsNullOrEmpty(searchString))
            {
                events = events.Where(e => e.Name.Contains(searchString));
            }

            return View(events);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            ViewBag.Clients = db.Clients.Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList();
            ViewBag.EventTypes = db.EventTypes.Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList();
            return View();
        }

        // POST: Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Event @event)
        {
            if (ModelState.IsValid)
            {
                @event.ApplicationUserId = User.Identity.GetUserId();
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(@event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.Clients = db.Clients.Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList();
            ViewBag.EventTypes = db.EventTypes.Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList();

            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
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
