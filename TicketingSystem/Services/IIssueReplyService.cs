using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TicketingSystem.Models;

namespace TicketingSystem.Services
{
    public interface IIssueReplyService : IBaseService<IssueReply>
    {
        List<IssueReply> RepliesForIssue(int? id);

        bool AddIssueReply(IssueReply issue);
    }
}