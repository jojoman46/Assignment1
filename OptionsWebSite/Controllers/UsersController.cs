using Microsoft.AspNet.Identity.EntityFramework;
using OptionsWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OptionsWebSite.Controllers
{
    public class UsersController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Users/Edit/5
        public ActionResult Edit(string id)
        {
            if(id == "A00111111")
            {
                ViewBag.ResultMessage = "Cannot modify A00111111";
                return View("Index",db.Users.ToList());
            }
            var listRoles = db.Roles.ToList();
            ViewBag.listRoles = listRoles;

            var role = db.Users.Where(r => r.UserName.Equals(id, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            /*
            var curRole = role.Roles;
            foreach(IdentityUserRole r in curRole)
            {
                foreach(IdentityRole idR in listRoles)
                {
                    if(idR.Id == r.RoleId)
                    {
                        ViewBag.curRole = idR.Name;
                        break;
                    }
                }
            }
            */
            List<SelectListItem> validRoles = new List<SelectListItem>();
            /*
            var data = new[]
            {
                new SelectListItem{ Value="10",Text="Winter" },
                new SelectListItem{ Value="20",Text="Spring/Summer" },
                new SelectListItem{ Value="30",Text="Fall" }
            };
            termList = data.ToList();
            */
            foreach (IdentityRole idR in listRoles)
            {
                SelectListItem temp = new SelectListItem
                {
                    Value = idR.Id,
                    Text = idR.Name
                };
                validRoles.Add(temp);
            }
            ViewBag.validRoles = validRoles;
            return View(role);
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
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
