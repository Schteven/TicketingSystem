using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicketingSystem.Models
{
    public class IssueReply : TEntity
    {
        [Key]
        [Display(Name = "IssueReply_Id", ResourceType = typeof(App_GlobalResources.globalUI))]
        public int IssueReply_Id { get; set; }

        [Display(Name = "Content", ResourceType = typeof(App_GlobalResources.globalUI))]
        public string Content { get; set; }

        [Display(Name = "Created", ResourceType = typeof(App_GlobalResources.globalUI))]
        public DateTime Created { get; set; }

        [Display(Name = "User_Id", ResourceType = typeof(App_GlobalResources.globalUI))]
        public virtual string User_Id { get; set; }
        [ForeignKey("User_Id")]
        public virtual ApplicationUser User { get; set; }

        public bool IsRead { get; set; }

        public bool IsSolved { get; set; }

        [Display(Name = "Issue_Id", ResourceType = typeof(App_GlobalResources.globalUI))]
        public virtual int IssueId { get; set; }
        [ForeignKey("IssueId")]
        public virtual Issue Issue { get; set; }

    }
}