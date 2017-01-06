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
        public int IssueReply_Id { get; set; }

        public string Content { get; set; }

        public DateTime Created { get; set; }

        public virtual string User_Id { get; set; }
        [ForeignKey("User_Id")]
        public virtual ApplicationUser User { get; set; }

        public bool IsRead { get; set; }

        public bool IsSolved { get; set; }

        public virtual int IssueId { get; set; }
        [ForeignKey("IssueId")]
        public virtual Issue Issue { get; set; }

    }
}