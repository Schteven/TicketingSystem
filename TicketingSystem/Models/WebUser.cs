using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicketingSystem.Models
{
    public class WebUser : TEntity 
    {
        public int WebUserId { get; set; }

        [Display(Name = "Firstname", ResourceType = typeof(App_GlobalResources.globalUI))]
        public string FirstName { get; set; }

        [Display(Name = "Lastname", ResourceType = typeof(App_GlobalResources.globalUI))]
        public string LastName { get; set; }


        [Display(Name = "PhoneNumber", ResourceType = typeof(App_GlobalResources.globalUI))]
        public int PhoneNumber { get; set; }

        [Display(Name = "Cellnumber", ResourceType = typeof(App_GlobalResources.globalUI))]
        public int CellNumber { get; set; }

        public bool IsActive { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public int ManagerId { get; set; }
        public virtual Manager Manager { get; set; }

        public virtual ICollection<Issue> Issues { get; set; }

        public virtual ICollection<IssueReply> IssueReplies { get; set; }

    }
}