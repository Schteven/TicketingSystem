using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TicketingSystem.Services;

namespace TicketingSystem.Models
{
    public class IssueService : BaseService<Issue>, IIssueService
    {
        public IssueService(IApplicationDbContext db) : base(db)
        {
        }

        public List<Issue> AllToManager(string id)
        {
            var issues = base.GetAll().Where(i => i.User.Manager == id).Where(i => i.IsDone == false).OrderByDescending(i => i.Priority).ThenBy(i => i.Created);
            return issues.ToList();
        }

        public List<Issue> AllToDispatcher()
        {
            var issues = base.GetAll().Where(i => i.IsDone == false).OrderByDescending(i => i.Priority).ThenBy(i => i.Created);
            return issues.ToList();
        }

        public List<Issue> AllToSolver(string id)
        {
            var issues = base.GetAll().Where(i => i.Solver_Id == id).Where(i => i.IsDone == false).OrderByDescending(i => i.Priority).ThenBy(i => i.Created);
            return issues.ToList();
        }

        public List<Issue> AllToUser(string id)
        {
            var issues = base.GetAll().Where(i => i.User_Id == id).Where(i => i.IsDone == false).OrderByDescending(i => i.Priority).ThenBy(i => i.Created);
            return issues.ToList();
        }

        public List<Issue> AllClosedIssuesToManager(string id)
        {
            var issues = base.GetAll().Where(i => i.User.Manager == id).Where(i => i.IsDone == true).OrderBy(i => i.IssueStatus);
            return issues.ToList();
        }

        public List<Issue> AllClosedIssuesToDispatcher()
        {
            var issues = base.GetAll().Where(i => i.IsDone == true).OrderBy(i => i.IssueStatus);
            return issues.ToList();
        }

        public List<Issue> AllClosedIssuesToSolver(string id)
        {
            var issues = base.GetAll().Where(i => i.Solver_Id == id).Where(i => i.IsDone == true).OrderBy(i => i.IssueStatus);
            return issues.ToList();
        }

        public List<Issue> AllClosedIssuesToUser(string id)
        {
            var issues = base.GetAll().Where(i => i.User_Id == id).Where(i => i.IsDone == true).OrderBy(i => i.IssueStatus);
            return issues.ToList();
        }

        public Issue SingleIssue(int? id)
        {
            Issue issue = base.Get(id);
            return issue;
        }

        public bool ModifyIssue(Issue issue)
        {
            base.Edit(issue);
            //base.db.Entry(issue).State = EntityState.Modified;
            //base.db.SaveChanges();
            return true;
        }

    }
}