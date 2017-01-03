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
using TicketingSystem.Services;
using System.Threading.Tasks;

namespace TicketingSystem.Controllers
{
    [Authorize]
    public class IssuesController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();

        private IIssueService issueService;
        private IIssueReplyService issueReplyService;
        private IUserService userService;

        public IssuesController(IIssueService issueService, IIssueReplyService issueReplyService, IUserService userService)
        {
            this.issueService = issueService;
            this.issueReplyService = issueReplyService;
            this.userService = userService;
        }

        private string currentUserId
        {
            get { return HttpContext.User.Identity.GetUserId(); }
            set { currentUserId = HttpContext.User.Identity.GetUserId(); }
        }


        // GET: Issues
        public ActionResult Index()
        {
            ICollection<Issue> issues = null;
            ICollection<Issue> closedIssues = null;

            string userRole = userService.GetUserRole(HttpContext.User.Identity.GetUserName());
            switch (userRole)
            {
                case "Administrator":
                case "Dispatcher":
                    issues = issueService.AllToDispatcher();
                    closedIssues = issueService.AllClosedIssuesToDispatcher();
                    break;

                case "Manager":
                    issues = issueService.AllToManager(currentUserId);
                    closedIssues = issueService.AllClosedIssuesToManager(currentUserId);
                    break;

                case "Solver":
                    issues = issueService.AllToSolver(currentUserId);
                    closedIssues = issueService.AllClosedIssuesToSolver(currentUserId);
                    break;

                case "User":
                    issues = issueService.AllToUser(currentUserId);
                    closedIssues = issueService.AllClosedIssuesToUser(currentUserId);
                    break;

                default:
                    return RedirectToAction("Login", "Account");

            }
            ViewBag.ClosedIssues = closedIssues;
            return View(issues);
        }

        // GET: Issues/Read/5
        public ActionResult Read(int? id)
        {

            if (id == null) { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }

            Issue issue = issueService.SingleIssue(id);

            if (issue == null) { return HttpNotFound(); }

            ICollection<IssueReply> replies = issueReplyService.RepliesForIssue(id);

            string userRole = userService.GetUserRole(HttpContext.User.Identity.GetUserName());
            if (replies.Count() == 0)
            {
                switch (userRole)
                {
                    case "Administrator":

                        break;

                    case "Manager":

                        break;

                    case "Dispatcher":

                        issue.IsRead = true;
                        issue.IssueStatus = Status.open;

                        if (issue.Solver.ApplicationUser.Id != currentUserId)
                        {
                            issue.IsRead = false;
                            issue.IssueStatus = Status.assigned;
                        }

                        issueService.ModifyIssue(issue);

                        break;

                    case "Solver":
                        issue.IsRead = true;
                        issue.IssueStatus = Status.open;

                        issueService.ModifyIssue(issue);

                        break;

                    case "User":

                        break;
                }
            }

            ViewBag.Replies = replies;
            ViewBag.currentUser = currentUserId;
            ViewBag.userRole = userRole;
            return View(issue);
        }
        // POST: Issues/Read (reply)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Read(Issue orIssue, string Reply, bool Solved)
        {
            
            string userRole = userService.GetUserRole(HttpContext.User.Identity.GetUserName());

            Issue issue = issueService.SingleIssue(orIssue.IssueId);
            WebUser user = userService.GetUser(currentUserId);

            IssueReply issueReply = new IssueReply();
            issueReply.Content = Reply;
            issueReply.Created = DateTime.Now;
            //issueReply.WebUserId = currentUserId;
            issueReply.Issue = issue;
            issueReply.IsRead = false;
            issueReply.Issue = issue;
            issueReply.Replier = user;

            issueReplyService.AddIssueReply(issueReply);

            switch (issue.IssueStatus)
            {
                case Status.canceled:
                case Status.closed:
                case Status.solved:
                    if (issue.IssueStatus == Status.solved)
                    {
                        if (currentUserId == issue.Issuer.ApplicationUser.Id)
                        {
                            issue.IssueStatus = Status.open;
                        }
                    }
                    break;
                case Status.assigned:
                case Status.@new:
                case Status.open:
                case Status.waiting:
                default:
                    if (Solved)
                    {
                        if (currentUserId == issue.Solver.ApplicationUser.Id) { issue.IssueStatus = Status.solved; }
                        else if (currentUserId == issue.Issuer.ApplicationUser.Id) { issue.IssueStatus = Status.closed; }
                    }
                    else
                    {
                        if (issue.Solver == user)
                        {
                            issue.IssueStatus = Status.waiting;
                        }
                        else
                        {
                            if (issue.IssueStatus == Status.waiting)
                            {
                                issue.IssueStatus = Status.open;
                            }
                        }
                    }
                    break;
            }

            issueService.ModifyIssue(issue);

            ICollection<IssueReply> replies = issueReplyService.RepliesForIssue(issue.IssueId);
            ViewBag.Replies = replies;
            ViewBag.currentUser = currentUserId;
            ViewBag.userRole = userRole;
            
            return View(issue);

        }

        // GET: Issues/Create
        public ActionResult Create()
        {
            //ViewBag.Solver_Id = new SelectList(db.Users, "Id", "Firstname");
            //ViewBag.User_Id = new SelectList(db.Users, "Id", "Firstname");
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
                /*var role = (from r in db.Roles where r.Name.Contains("Dispatcher") select r).FirstOrDefault();
                ApplicationUser dispatcher = db.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(role.Id)).FirstOrDefault();
                issue.Solver_Id = dispatcher.Id;
                issue.Created = DateTime.Now;
                issue.User_Id = User.Identity.GetUserId();
                issue.IssueStatus = Status.@new;

                issueService.Create(issue);

                return RedirectToAction("Index");*/
            }

            //ViewBag.Solver_Id = new SelectList(db.Users, "Id", "Firstname", issue.Solver_Id);
            //ViewBag.User_Id = new SelectList(db.Users, "Id", "Firstname", issue.User_Id);
            return View(issue);
        }

        // GET: Issues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Issue issue = issueService.SingleIssue(id);
            if (issue == null)
            {
                return HttpNotFound();
            }
            //var role = (from r in db.Roles where r.Name.Contains("Solver") select r).FirstOrDefault();
            //ViewBag.Solver_Id = new SelectList(db.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(role.Id)), "Id", "Firstname", issue.Solver_Id);
            //ViewBag.User_Id = new SelectList(db.Users, "Id", "Firstname", issue.User_Id);
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
                if (issue.Solver.WebUserId != 0)
                {
                    issue.IssueStatus = Status.assigned;
                }

                issueService.ModifyIssue(issue);

                return RedirectToAction("Index");
            }
            //ViewBag.Solver_Id = new SelectList(db.Users, "Id", "Firstname", issue.Solver_Id);
            //ViewBag.User_Id = new SelectList(db.Users, "Id", "Firstname", issue.User_Id);
            return View(issue);
        }
        // POST: Issues/Cancel
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cancel(Issue orIssue, string Reply)
        {
            Issue issue = issueService.SingleIssue(orIssue.IssueId);
            WebUser user = userService.GetUser(currentUserId);
            if (issue == null)
            {
                return HttpNotFound();
            }
            issue.IssueStatus = Status.canceled;
            issue.IsDone = true;

            issueService.ModifyIssue(issue);

            IssueReply issueReply = new IssueReply();
            issueReply.Content = Reply;
            issueReply.Created = DateTime.Now;
            //issueReply.WebUserId = currentUserId;
            issueReply.Issue = issue;
            issueReply.IsRead = false;
            issueReply.Issue = issue;
            issueReply.Replier = user;

            issueReplyService.AddIssueReply(issueReply);

            return RedirectToAction("Read", new { id = issue.IssueId });
        }

        // GET: Issues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Issue issue = issueService.SingleIssue(id);
            if (issue == null)
            {
                return HttpNotFound();
            }
            return View(issue);
        }

        // POST: Issues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Issue issue = issueService.SingleIssue(id);
            issueService.Delete(id);
            return RedirectToAction("Index");
        }

        /*protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}
