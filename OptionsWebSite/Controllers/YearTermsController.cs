﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DiplomaDataModel.Option;

namespace OptionsWebSite.Controllers
{
    public class YearTermsController : Controller
    {
        private OptionContext db = new OptionContext();

        // GET: YearTerms
        public ActionResult Index()
        {
            return View(db.YearTerms.ToList());
        }

        // GET: YearTerms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearTerm yearTerm = db.YearTerms.Find(id);
            if (yearTerm == null)
            {
                return HttpNotFound();
            }
            return View(yearTerm);
        }

        // GET: YearTerms/Create
        public ActionResult Create()
        {
            List<SelectListItem> termList = new List<SelectListItem>();
            var data = new[]
            {
                new SelectListItem{ Value="10",Text="Winter" },
                new SelectListItem{ Value="20",Text="Spring/Summer" },
                new SelectListItem{ Value="30",Text="Fall" }
            };
            termList = data.ToList();
            ViewBag.Term = termList;

            return View();
        }

        // POST: YearTerms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "YearTermId,Year,Term,IsDefault")] YearTerm yearTerm)
        {
            if (ModelState.IsValid)
            {
                db.YearTerms.Add(yearTerm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<SelectListItem> termList = new List<SelectListItem>();
            var data = new[]
            {
                new SelectListItem{ Value="10",Text="Winter" },
                new SelectListItem{ Value="20",Text="Spring/Summer" },
                new SelectListItem{ Value="30",Text="Fall" }
            };
            termList = data.ToList();
            ViewBag.Term = termList;
            return View(yearTerm);
        }

        // GET: YearTerms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearTerm yearTerm = db.YearTerms.Find(id);
            if (yearTerm == null)
            {
                return HttpNotFound();
            }

            List<SelectListItem> termList = new List<SelectListItem>();
            var data = new[]
            {
                new SelectListItem{ Value="10",Text="Winter" },
                new SelectListItem{ Value="20",Text="Spring/Summer" },
                new SelectListItem{ Value="30",Text="Fall" }
            };
            termList = data.ToList();
            ViewBag.Term = termList;
            return View(yearTerm);
        }

        // POST: YearTerms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "YearTermId,Year,Term,IsDefault")] YearTerm yearTerm)
        {
            if (ModelState.IsValid)
            {
                
                if (yearTerm.IsDefault)
                {
                    var c = (from x in db.YearTerms
                             where x.IsDefault == true
                             select x).First();

                    // do your stuff  
                    c.IsDefault = false;
                }
                //else
                //{
                //    return RedirectToAction("Index");
                //}     


                db.Entry(yearTerm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            List<SelectListItem> termList = new List<SelectListItem>();
            var data = new[]
            {
               new SelectListItem{ Value="10",Text="Winter" },
                new SelectListItem{ Value="20",Text="Spring/Summer" },
                new SelectListItem{ Value="30",Text="Fall" }
            };
            termList = data.ToList();
            ViewBag.Term = termList;
            return View(yearTerm);
        }

        // GET: YearTerms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearTerm yearTerm = db.YearTerms.Find(id);
            if (yearTerm == null)
            {
                return HttpNotFound();
            }
            return View(yearTerm);
        }

        // POST: YearTerms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            YearTerm yearTerm = db.YearTerms.Find(id);
            db.YearTerms.Remove(yearTerm);
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
