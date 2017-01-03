using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using TicketingSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketingSystem.Models
{
    public enum Level
    {
        low,
        medium,
        high,
        immediate
    }

    public enum Status
    {
        @new,
        assigned,
        open,
        waiting,
        solved,
        closed,
        canceled,
        denied
    }

    public class Issue : TEntity
    {
        public int IssueId { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Subject { get; set; }

        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public Level? Priority { get; set; }

        public Status? IssueStatus { get; set; }

        public DateTime Created { get; set; }

        public bool IsRead { get; set; }
        public bool IsDone { get; set; }

        public int IssuerId { get; set; }
        public virtual WebUser Issuer { get; set; }

        public int SolverId { get; set; }
        public virtual WebUser Solver { get; set; }

        public virtual ICollection<IssueReply> IssueReplies { get; set; }

        public Issue()
        {

        }
    }
}