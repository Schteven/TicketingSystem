using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TicketingSystem.Models;
using TicketingSystem.Services;

namespace TicketingSystem.Views
{
    [Authorize(Roles="Administrator")]
    public class UsersController : Controller
    {
        private IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        // GET: Users
        public ActionResult Index()
        {
            return View(userService.AllUsers());
        }

        // GET: Users/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebUser applicationUser = userService.GetUser(id);
            //ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            //var roleManager = (from r in db.Roles where r.Name.Contains("Manager") select r).FirstOrDefault();
            //var roleAdministrator = (from r in db.Roles where r.Name.Contains("Administrator") select r).FirstOrDefault();
            //ViewBag.Manager = new SelectList(db.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(roleManager.Id) || x.Roles.Select(y => y.RoleId).Contains(roleAdministrator.Id)).Select(s => new { Id = s.Id, Description = s.Firstname + " (" + s.Department + ")" }), "Id", "Description");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Firstname,Lastname,Cellnumber,Department,Manager,Email,PhoneNumber,UserName")] WebUser webUser, string Manager)
        {
            /*if (ModelState.IsValid)
            {
                //var departmentManager = (from r in db.Users where r.Id.Contains(Manager) select r.Department).FirstOrDefault();
                var newUser = new WebUser
                {
                    FirstName = webUser.FirstName,
                    LastName = webUser.LastName,
                    CellNumber = webUser.CellNumber,
                    PhoneNumber = webUser.PhoneNumber,
                    Manager = Manager,
                    Department = departmentManager,
                    UserName = webUser.UserName,
                    Email = webUser.Email,
                    IsActive = true
                };
                var result = await UserManager.CreateAsync(newUser, "demo");
                if (result.Succeeded)
                {
                    var addtorole = UserManager.AddToRole(newUser.Id, "User");
                    return RedirectToAction("Index", "Users");
                }
                AddErrors(result);
            }

            var roleManager = (from r in db.Roles where r.Name.Contains("Manager") select r).FirstOrDefault();
            var roleAdministrator = (from r in db.Roles where r.Name.Contains("Administrator") select r).FirstOrDefault();
            ViewBag.Manager = new SelectList(db.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(roleManager.Id) || x.Roles.Select(y => y.RoleId).Contains(roleAdministrator.Id)).Select(s => new { Id = s.Id, Description = s.Firstname + " (" + s.Department + ")" }), "Id", "Description");
            */
            return View(webUser);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebUser WebUser = userService.GetUser(id);
            //ApplicationUser applicationUser = db.Users.Find(id);
            if (WebUser == null)
            {
                return HttpNotFound();
            }
            //var roleManager = (from r in db.Roles where r.Name.Contains("Manager") select r).FirstOrDefault();
            //var roleAdministrator = (from r in db.Roles where r.Name.Contains("Administrator") select r).FirstOrDefault();
            //ViewBag.Manager = new SelectList(db.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(roleManager.Id) || x.Roles.Select(y => y.RoleId).Contains(roleAdministrator.Id)).Select(s => new { Id = s.Id, Description = s.Firstname + " (" + s.Department + ")" }), "Id", "Description", applicationUser.Manager);
            return View(WebUser);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Firstname,Lastname,Cellnumber,Department,Manager,Email,PhoneNumber,UserName,PasswordHash,SecurityStamp,IsActive")] WebUser webUser, string Manager)
        {
            /*if (ModelState.IsValid)
            {
                applicationUser.Manager = Manager;
                var departmentManager = (from r in db.Users where r.Id.Contains(Manager) select r.Department).FirstOrDefault();
                applicationUser.Department = departmentManager;

                db.Entry(applicationUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var roleManager = (from r in db.Roles where r.Name.Contains("Manager") select r).FirstOrDefault();
            var roleAdministrator = (from r in db.Roles where r.Name.Contains("Administrator") select r).FirstOrDefault();
            ViewBag.Manager = new SelectList(db.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(roleManager.Id) || x.Roles.Select(y => y.RoleId).Contains(roleAdministrator.Id)).Select(s => new { Id = s.Id, Description = s.Firstname + " (" + s.Department + ")" }), "Id", "Description", applicationUser.Manager);
            */
            return View(webUser);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebUser webUser = userService.GetUser(id);
            //ApplicationUser applicationUser = db.Users.Find(id);
            if (webUser == null)
            {
                return HttpNotFound();
            }
            return View(webUser);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            WebUser webUser = userService.GetUser(id);
            //ApplicationUser applicationUser = db.Users.Find(id);
            return RedirectToAction("Index");
        }
    }
}
