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
        [Key]
        [Display(Name = "IssueId", ResourceType = typeof(App_GlobalResources.globalUI))]
        public int IssueId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Subject", ResourceType = typeof(App_GlobalResources.globalUI))]
        public string Subject { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Content", ResourceType = typeof(App_GlobalResources.globalUI))]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Priority", ResourceType = typeof(App_GlobalResources.globalUI))]
        public Level? Priority { get; set; }

        [Display(Name = "IssueStatus", ResourceType = typeof(App_GlobalResources.globalUI))]
        public Status? IssueStatus { get; set; }

        [Display(Name = "Created", ResourceType = typeof(App_GlobalResources.globalUI))]
        public DateTime Created { get; set; }

        public bool IsRead { get; set; }
        public bool IsDone { get; set; }

        [Display(Name = "User_Id", ResourceType = typeof(App_GlobalResources.globalUI))]
        public virtual string User_Id { get; set; }

        [Display(Name = "Issuer")]
        [ForeignKey("User_Id")]
        public virtual ApplicationUser User { get; set; }

        [Display(Name = "Solver_Id", ResourceType = typeof(App_GlobalResources.globalUI))]
        public virtual string Solver_Id { get; set; }
        [Display(Name = "Solver")]
        [ForeignKey("Solver_Id")]
        public virtual ApplicationUser Solver { get; set; }

        [Display(Name = "IssueReplies", ResourceType = typeof(App_GlobalResources.globalUI))]
        public virtual ICollection<IssueReply> IssueReplies { get; set; }

        public Issue()
        {

        }
    }
}