using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicketingSystem.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        public string Name { get; set; }

        public int ManagerId { get; set; }
        public virtual Manager Manager { get; set; }

        public ICollection<WebUser> WebUsers { get; set; }
    }
}