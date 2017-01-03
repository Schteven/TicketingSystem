using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TicketingSystem.Models;

namespace TicketingSystem.Services
{
    public interface IIssueService : IBaseService<Issue>
    {
        List<Issue> AllToManager(string id);

        List<Issue> AllToDispatcher();

        List<Issue> AllToSolver(string id);

        List<Issue> AllToUser(string id);

        List<Issue> AllClosedIssuesToManager(string id);

        List<Issue> AllClosedIssuesToDispatcher();

        List<Issue> AllClosedIssuesToSolver(string id);

        List<Issue> AllClosedIssuesToUser(string id);

        Issue SingleIssue(int? id);

        bool ModifyIssue(Issue issue);
    }
}