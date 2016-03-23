using OptionsWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OptionsWebSite.Controllers
{
    public class RolesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Roles
        public ActionResult Index()
        {
            return View(db.Roles.ToList());
        }

        // GET: Roles/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var roleName = collection["roleName"];

            if(roleName == "")
            {
                ViewBag.ResultMessage = "ERROR CANT BE EMPTY";
                return View("Index",db.Roles.ToList());
            }

            try
            {
                // TODO: Add insert logic here
                db.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
                {
                    Name = roleName
                });
                db.SaveChanges();
                ViewBag.ResultMessage = "Role Added Successfully";
                return View("Index", db.Roles.ToList());
            }
            catch
            {
                ViewBag.ResultMessage = "Role Already There";
                return View("Index", db.Roles.ToList());
            }
        }

        // GET: Roles/Edit/Admin
        public ActionResult Edit(string id)
        {
            ViewBag.Name = id;
            var role = db.Roles.Where(r => r.Name.Equals(id, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            return View(role);
        }

        // POST: Roles/Edit/Admin
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                
                var roleName = collection["Name"];
                var prevRoleName = collection["Id"];
                var role = db.Roles.Where(r => r.Name.Equals(prevRoleName)).FirstOrDefault();
                if (role == null)
                {
                    ViewBag.ResultMessage = "Role Not There";
                    return View("Index", db.Roles.ToList());
                }
                role.Name = roleName;
                db.Entry(role).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return View("Index", db.Roles.ToList());
            }
            catch
            {
                return View();
            }
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(string id)
        {
            var role = db.Roles.Where(r => r.Name.Equals(id)).FirstOrDefault();
            db.Roles.Remove(role);
            db.SaveChanges();
            ViewBag.ResultMessage = "Role Deleted";
            return View("Index",db.Roles.ToList());
        }

        // POST: Roles/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
