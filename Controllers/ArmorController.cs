using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PlainsOfPrimus.Models;

namespace PlainsOfPrimus.Controllers
{
    public class ArmorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Armor
        public ActionResult Index()
        {
            return View(db.Armors.ToList());
        }

        // GET: Armor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Armor armor = db.Armors.Find(id);
            if (armor == null)
            {
                return HttpNotFound();
            }
            return View(armor);
        }

        // GET: Armor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Armor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type,Name,Image,ArmorValue,Health,Intellect,Strength,Agility")] Armor armor)
        {
            if (ModelState.IsValid)
            {
                db.Armors.Add(armor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(armor);
        }

        // GET: Armor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Armor armor = db.Armors.Find(id);
            if (armor == null)
            {
                return HttpNotFound();
            }
            return View(armor);
        }

        // POST: Armor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type,Name,Image,ArmorValue,Health,Intellect,Strength,Agility")] Armor armor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(armor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(armor);
        }

        // GET: Armor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Armor armor = db.Armors.Find(id);
            if (armor == null)
            {
                return HttpNotFound();
            }
            return View(armor);
        }

        // POST: Armor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Armor armor = db.Armors.Find(id);
            db.Armors.Remove(armor);
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
