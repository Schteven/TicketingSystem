using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TicketingSystem.Services;

namespace TicketingSystem.Models
{
    public class IssueReplyService : BaseService<IssueReply>, IIssueReplyService
    {
        public IssueReplyService(IApplicationDbContext db) : base(db)
        {
        }

        public bool AddIssueReply(IssueReply issueReply)
        {
            base.Create(issueReply);
            return true;
        }

        public List<IssueReply> RepliesForIssue(int? id)
        {
            var issues = base.GetAll().Where(i => i.Issue.IssueId == id);
            return issues.ToList();
        }
    }
}