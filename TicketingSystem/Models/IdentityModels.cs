using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Resources;
using TicketingSystem.Services;

namespace TicketingSystem.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Key]
        public override string Id
        {
            get
            {
                return base.Id;
            }

            set
            {
                base.Id = value;
            }
        }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        [Display(Name = "UserName", ResourceType = typeof(App_GlobalResources.globalUI))]
        public override string UserName { get; set; }

        [Display(Name = "Email", ResourceType = typeof(App_GlobalResources.globalUI))]
        public override string Email { get; set; }

        /*********************************************************/
        
        public int WebUserId { get; set; }
        public virtual WebUser WebUser { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {

        public DbSet<Issue> Issues { get; set; }
        public DbSet<IssueReply> IssueReplies { get; set; }
        public DbSet<WebUser> WebUsers { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Department> Departments { get; set; }

        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<WebUser>()
                        .HasKey(wu => wu.WebUserId);

            modelBuilder.Entity<IssueReply>()
                        .HasKey(ir => ir.IssueReplyId);

            modelBuilder.Entity<Issue>()
                        .HasKey(i => i.IssueId);

            modelBuilder.Entity<WebUser>()
                        .HasOptional(wu => wu.ApplicationUser)
                        .WithRequired(au => au.WebUser)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<WebUser>()
                        .HasOptional(wu => wu.Manager)
                        .WithRequired(m => m.WebUser)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Department>()
                        .HasOptional(d => d.Manager)
                        .WithRequired(m => m.Department)
                        .WillCascadeOnDelete(false);
            
            modelBuilder.Entity<WebUser>()
                        .HasRequired<Department>(wu => wu.Department)
                        .WithMany(d => d.WebUsers)
                        .HasForeignKey(wu => wu.DepartmentId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Issue>()
                        .HasRequired<WebUser>(i => i.Issuer)
                        .WithMany(wu => wu.Issues)
                        .HasForeignKey(i => i.IssuerId)
                        .WillCascadeOnDelete(false);

            /*modelBuilder.Entity<Issue>()
                        .HasRequired<WebUser>(i => i.Solver)
                        .WithMany(wu => wu.Issues)
                        .HasForeignKey(i => i.SolverId)
                        .WillCascadeOnDelete(false);
            */
            modelBuilder.Entity<IssueReply>()
                        .HasRequired<Issue>(ir => ir.Issue)
                        .WithMany(i => i.IssueReplies)
                        .HasForeignKey(ir => ir.IssueId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<IssueReply>()
                        .HasRequired<WebUser>(i => i.Replier)
                        .WithMany(wu => wu.IssueReplies)
                        .HasForeignKey(i => i.ReplierId)
                        .WillCascadeOnDelete(false);

        }

    }

}