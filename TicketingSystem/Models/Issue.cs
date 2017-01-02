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
        solved,
        closed,
        canceled,
        waiting,
        denied
    }

    public class Issue
    {

        public int IssueId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Subject { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Required]
        public Level? Priority { get; set; }

        public Status? IssueStatus { get; set; }

        public DateTime Created { get; set; }

        public bool IsRead { get; set; }

        public virtual string User_Id { get; set; }
        [Display(Name = "Issuer")]
        [ForeignKey("User_Id")]
        public virtual ApplicationUser User { get; set; }
        
        public virtual string Solver_Id { get; set; }
        [Display(Name = "Solver")]
        [ForeignKey("Solver_Id")]
        public virtual ApplicationUser Solver { get; set; }

        public virtual ICollection<IssueReply> IssueReplies { get; set; }

        public Issue()
        {

        }
    }
}