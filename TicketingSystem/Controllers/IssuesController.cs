using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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

namespace TicketingSystem.Controllers
{
    [Authorize]
    public class IssuesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

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

        private string currentUserId
        {
            get { return HttpContext.User.Identity.GetUserId(); }
            set { currentUserId = HttpContext.User.Identity.GetUserId(); }
        }
        public async System.Threading.Tasks.Task<string> GetUserRole()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            IdentityUserRole identityUserRole = UserManager.FindByName(HttpContext.User.Identity.GetUserName()).Roles.FirstOrDefault();
            IdentityRole userRole = await roleManager.FindByIdAsync(identityUserRole.RoleId);

            return userRole.Name;
        }

        // GET: Issues
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            var issues = db.Issues.Include(i => i.Solver).Include(i => i.User).Where(i => i.IssueId == 0);
            string userRole = await GetUserRole();
            switch (userRole)
            {
                case "Administrator":
                    issues = db.Issues.Include(i => i.Solver).Include(i => i.User);
                    break;

                case "Manager":
                    var usersOfManager = (from r in db.Users where r.Manager.Contains(currentUserId) select r).ToList();
                    issues = db.Issues.Include(i => i.Solver).Include(i => i.User).Where(i => i.User.Manager.Contains(currentUserId));
                    break;

                case "Dispatcher":
                    issues = db.Issues.Include(i => i.Solver).Include(i => i.User);
                    break;

                case "Solver":
                    issues = db.Issues.Include(i => i.Solver).Include(i => i.User).Where(i => i.Solver_Id == currentUserId);
                    break;

                case "User":
                    issues = db.Issues.Include(i => i.Solver).Include(i => i.User).Where(i => i.User.Id.Contains(currentUserId));
                    break;

                default:
                    return RedirectToAction("Login", "Account");
                    
            }
            return View(issues.ToList());
        }


        // GET: Issues/Details/5
        public async System.Threading.Tasks.Task<ActionResult> Read(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Issue issue = db.Issues.Find(id);
            if (issue == null)
            {
                return HttpNotFound();
            }
            string userRole = await GetUserRole();
            switch (userRole)
            {
                case "Administrator":

                    break;

                case "Manager":

                    break;

                case "Dispatcher":
                    issue.IsRead = true;
                    issue.IssueStatus = Status.open;
                    if (issue.Solver_Id != currentUserId)
                    {
                        issue.IsRead = false;
                        issue.IssueStatus = Status.assigned;
                    }
                    db.Entry(issue).State = EntityState.Modified;
                    db.SaveChanges();
                    break;

                case "Solver":
                    issue.IsRead = true;
                    issue.IssueStatus = Status.open;
                    db.Entry(issue).State = EntityState.Modified;
                    db.SaveChanges();
                    break;

                case "User":
                    
                    break;
            }
            ViewBag.currentUser = currentUserId;
            ViewBag.userRole = userRole;
            return View(issue);
        }

        // GET: Issues/Create
        public ActionResult Create()
        {
            ViewBag.Solver_Id = new SelectList(db.Users, "Id", "Firstname");
            ViewBag.User_Id = new SelectList(db.Users, "Id", "Firstname");
            return View();
        }

        // POST: Issues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IssueId,Subject,Content,Priority")] Issue issue)
        {
            if (ModelState.IsValid)
            {
                var role = (from r in db.Roles where r.Name.Contains("Dispatcher") select r).FirstOrDefault();
                ApplicationUser dispatcher = db.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(role.Id)).FirstOrDefault();
                issue.Solver_Id = dispatcher.Id;
                issue.Created = DateTime.Now;
                issue.User_Id = User.Identity.GetUserId();
                issue.IssueStatus = Status.@new;
                db.Issues.Add(issue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Solver_Id = new SelectList(db.Users, "Id", "Firstname", issue.Solver_Id);
            ViewBag.User_Id = new SelectList(db.Users, "Id", "Firstname", issue.User_Id);
            return View(issue);
        }

        // GET: Issues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Issue issue = db.Issues.Find(id);
            if (issue == null)
            {
                return HttpNotFound();
            }
            var role = (from r in db.Roles where r.Name.Contains("Solver") select r).FirstOrDefault();
            ViewBag.Solver_Id = new SelectList(db.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(role.Id)), "Id", "Firstname", issue.Solver_Id);
            ViewBag.User_Id = new SelectList(db.Users, "Id", "Firstname", issue.User_Id);
            return View(issue);
        }

        // POST: Issues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IssueId,Subject,Content,Priority,IssueStatus,Created,User_Id,Solver_Id")] Issue issue)
        {
            if (ModelState.IsValid)
            {
                if (issue.Solver_Id != null)
                {
                    issue.IssueStatus = Status.assigned;
                }
                db.Entry(issue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Solver_Id = new SelectList(db.Users, "Id", "Firstname", issue.Solver_Id);
            ViewBag.User_Id = new SelectList(db.Users, "Id", "Firstname", issue.User_Id);
            return View(issue);
        }

        // GET: Issues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Issue issue = db.Issues.Find(id);
            if (issue == null)
            {
                return HttpNotFound();
            }
            return View(issue);
        }

        // POST: Issues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Issue issue = db.Issues.Find(id);
            db.Issues.Remove(issue);
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
