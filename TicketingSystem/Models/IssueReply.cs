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
        public int IssueReplyId { get; set; }
        public string Content { get; set; }

        public DateTime Created { get; set; }

        public bool IsRead { get; set; }

        public int ReplierId { get; set; }
        public virtual WebUser Replier { get; set; }

        public int IssueId { get; set; }
        public virtual Issue Issue { get; set; }
    }
}