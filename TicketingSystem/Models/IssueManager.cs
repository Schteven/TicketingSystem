using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicketingSystem.Models
{
    public class IssueManager
    {
        public string IssueManagerId { get; set; }

        public virtual int IssueId { get; set; }
        [ForeignKey("IssueId")]
        public virtual Issue Issue { get; set; }

        public virtual string User_Id { get; set; }
        [ForeignKey("User_Id")]
        public virtual ApplicationUser Solver { get; set; }

        public IssueManager()
        {

        }
    }
}