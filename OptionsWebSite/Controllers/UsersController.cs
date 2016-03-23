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
            var user = db.Users.Where(r => r.UserName.Equals(id, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var listOfCurrentRoles = new List<string>();

            foreach(IdentityUserRole tempUserRole in user.Roles)
            {
                var roleId = tempUserRole.RoleId;
                foreach(IdentityRole tempUser in db.Roles)
                {
                    if(roleId == tempUser.Id)
                    {
                        listOfCurrentRoles.Add(tempUser.Name);
                    }
                }
            }
            
            var listRoles = db.Roles.ToList();
            List<SelectListItem> validRoles = new List<SelectListItem>();
            foreach (IdentityRole idR in listRoles)
            {
                SelectListItem temp = new SelectListItem
                {
                    Value = idR.Id,
                    Text = idR.Name
                };
                validRoles.Add(temp);
            }
            ViewBag.listOfCurrentRoles = listOfCurrentRoles;
            ViewBag.validRoles = validRoles;
            return View(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                ViewBag.ResultMessage = collection["validRoles"] + " " + collection["UserName"];
                var user = db.Users.Where(r => r.UserName.Equals(id, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                var role = new IdentityRole();

                foreach(IdentityUserRole tempUserRole in user.Roles)
                {
                    if(collection["validRoles"] == tempUserRole.RoleId)
                    {
                        ViewBag.ResultMessage = "Role already added to the user";
                        return View("Index", db.Users.ToList());
                    }
                }

                foreach (IdentityRole tempRole in db.Roles)
                {
                    if (collection["validRoles"] == tempRole.Id)
                    {
                        Response.Write(tempRole.Name + " " + tempRole.Id);
                        role = tempRole;
                    }
                }

                var idRole = new IdentityUserRole()
                {
                    UserId = user.Id,
                    RoleId = role.Id
                };
                user.Roles.Add(idRole);
                db.SaveChanges();
                return View("Index", db.Users.ToList());
            }
            catch
            {
                //ViewBag.ResultMessage = "ERROR";
                return View("Index", db.Users.ToList());
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
