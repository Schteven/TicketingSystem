using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicketingSystem.Models
{
    public class Manager
    {
        public int ManagerId { get; set; }

        public int WebUserId { get; set; }
        public virtual WebUser WebUser { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}