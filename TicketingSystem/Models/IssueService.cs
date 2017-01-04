using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TicketingSystem.Services;

namespace TicketingSystem.Models
{
    public class IssueService : IIssueService
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IssueService()
        {
            db = new ApplicationDbContext();
        }

        public List<Issue> AllToManager(string id)
        {

            var issues = (from issue in db.Issues
                          join user in db.Users on issue.User_Id equals user.Id into User
                          join solver in db.Users on issue.Solver_Id equals solver.Id into Solver
                          where (issue.User.Manager == id) && (issue.IsDone == false)
                          orderby issue.Priority descending, issue.Created ascending
                          select issue
                          );

            return issues.ToList();
        }
        
        public List<Issue> AllToDispatcher()
        {
            var issues = (from issue in db.Issues
                          join user in db.Users on issue.User_Id equals user.Id into User
                          join solver in db.Users on issue.Solver_Id equals solver.Id into Solver
                          where (issue.IsDone == false)
                          orderby issue.Priority descending, issue.Created ascending
                          select issue
                          );

            return issues.ToList();
        }

        public List<Issue> AllToSolver(string id)
        {
            var issues = (from issue in db.Issues
                          join user in db.Users on issue.User_Id equals user.Id into User
                          join solver in db.Users on issue.Solver_Id equals solver.Id into Solver
                          where (issue.Solver_Id == id) && (issue.IsDone == false)
                          orderby issue.Priority descending, issue.Created ascending
                          select issue
                          );
            return issues.ToList();
        }

        public List<Issue> AllToUser(string id)
        {
            var issues = (from issue in db.Issues
                          join user in db.Users on issue.User_Id equals user.Id into User
                          join solver in db.Users on issue.Solver_Id equals solver.Id into Solver
                          where (issue.User_Id == id) && (issue.IsDone == false)
                          orderby issue.Priority descending, issue.Created ascending
                          select issue
                          );

            return issues.ToList();
        }

        public List<Issue> AllClosedIssuesToManager(string id)
        {
            var issues = (from issue in db.Issues
                          join user in db.Users on issue.User_Id equals user.Id into User
                          join solver in db.Users on issue.Solver_Id equals solver.Id into Solver
                          where (issue.User.Manager == id) && (issue.IsDone == true)
                          orderby issue.Created descending
                          select issue
                          );

            return issues.ToList();
        }

        public List<Issue> AllClosedIssuesToDispatcher()
        {
            var issues = (from issue in db.Issues
                          join user in db.Users on issue.User_Id equals user.Id into User
                          join solver in db.Users on issue.Solver_Id equals solver.Id into Solver
                          where (issue.IsDone == true)
                          orderby issue.Created descending
                          select issue
                          );

            return issues.ToList();
        }

        public List<Issue> AllClosedIssuesToSolver(string id)
        {
            var issues = (from issue in db.Issues
                          join user in db.Users on issue.User_Id equals user.Id into User
                          join solver in db.Users on issue.Solver_Id equals solver.Id into Solver
                          where (issue.Solver_Id == id) && (issue.IsDone == true)
                          orderby issue.Created descending
                          select issue
                          );

            return issues.ToList();
        }

        public List<Issue> AllClosedIssuesToUser(string id)
        {
            var issues = (from issue in db.Issues
                          join user in db.Users on issue.User_Id equals user.Id into User
                          join solver in db.Users on issue.Solver_Id equals solver.Id into Solver
                          where (issue.User_Id == id) && (issue.IsDone == true)
                          orderby issue.Created descending
                          select issue
                          );

            return issues.ToList();
        }

        public Issue SingleIssue(int? id)
        {
            Issue issue = db.Issues.Find(id);

            return issue;
        }

        public List<IssueReply> RepliesForIssue(int? id)
        {
            var issueReplies = db.IssueReplies.Where(i => i.IssueId == id).ToList();

            return issueReplies;
        }
    }
}