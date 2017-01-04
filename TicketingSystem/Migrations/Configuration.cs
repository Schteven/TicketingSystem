namespace TicketingSystem.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TicketingSystem.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TicketingSystem.Models.ApplicationDbContext context)
        {
            /*context.IssueStatuses.AddOrUpdate(
                new IssueStatus { IssueStatusId = 1, IssueStatusName = "New" },
                new IssueStatus { IssueStatusId = 2, IssueStatusName = "Assigned" },
                new IssueStatus { IssueStatusId = 3, IssueStatusName = "Open" },
                new IssueStatus { IssueStatusId = 4, IssueStatusName = "Solved" },
                new IssueStatus { IssueStatusId = 5, IssueStatusName = "Closed" },
                new IssueStatus { IssueStatusId = 6, IssueStatusName = "Canceled" },
                new IssueStatus { IssueStatusId = 7, IssueStatusName = "Waiting" },
                new IssueStatus { IssueStatusId = 8, IssueStatusName = "Denied" }
            );
            */
            /*context.Users.AddOrUpdate(
                new ApplicationUser { Firstname = "Eva",    Email = "dispatcher@dispatcher.net",    UserName = "dispatcher",    PasswordHash = "AERKKvjQxbgEBQJtyfc8Jdony+KRbQ1v6vrxSbJEda6hFvs/6m8/K9x03YX6l1cBSw==" },
                new ApplicationUser { Firstname = "Mark",   Email = "solver1@solver.net",           UserName = "solver1",       PasswordHash = "AERKKvjQxbgEBQJtyfc8Jdony+KRbQ1v6vrxSbJEda6hFvs/6m8/K9x03YX6l1cBSw==" },
                new ApplicationUser { Firstname = "Willem", Email = "solver2@solver.net",           UserName = "solver2",       PasswordHash = "AERKKvjQxbgEBQJtyfc8Jdony+KRbQ1v6vrxSbJEda6hFvs/6m8/K9x03YX6l1cBSw==" },
                new ApplicationUser { Firstname = "Erik",   Email = "manager1@manager.net",         UserName = "manager1",      PasswordHash = "AERKKvjQxbgEBQJtyfc8Jdony+KRbQ1v6vrxSbJEda6hFvs/6m8/K9x03YX6l1cBSw==" },
                new ApplicationUser { Firstname = "Magda",  Email = "manager2@manager.net",         UserName = "manager2",      PasswordHash = "AERKKvjQxbgEBQJtyfc8Jdony+KRbQ1v6vrxSbJEda6hFvs/6m8/K9x03YX6l1cBSw==" },
                new ApplicationUser { Firstname = "Luc",    Email = "manager3@manager.net",         UserName = "manager3",      PasswordHash = "AERKKvjQxbgEBQJtyfc8Jdony+KRbQ1v6vrxSbJEda6hFvs/6m8/K9x03YX6l1cBSw==" },
                new ApplicationUser { Firstname = "Eddy",   Email = "user1@user.net",               UserName = "user1",         PasswordHash = "AERKKvjQxbgEBQJtyfc8Jdony+KRbQ1v6vrxSbJEda6hFvs/6m8/K9x03YX6l1cBSw==" },
                new ApplicationUser { Firstname = "Vera",   Email = "user2@user.net",               UserName = "user2",         PasswordHash = "AERKKvjQxbgEBQJtyfc8Jdony+KRbQ1v6vrxSbJEda6hFvs/6m8/K9x03YX6l1cBSw==" },
                new ApplicationUser { Firstname = "Anita",  Email = "user3@user.net",               UserName = "user3",         PasswordHash = "AERKKvjQxbgEBQJtyfc8Jdony+KRbQ1v6vrxSbJEda6hFvs/6m8/K9x03YX6l1cBSw==" },
                new ApplicationUser { Firstname = "Alain",  Email = "user4@user.net",               UserName = "user4",         PasswordHash = "AERKKvjQxbgEBQJtyfc8Jdony+KRbQ1v6vrxSbJEda6hFvs/6m8/K9x03YX6l1cBSw==" },
                new ApplicationUser { Firstname = "Michel", Email = "user5@user.net",               UserName = "user5",         PasswordHash = "AERKKvjQxbgEBQJtyfc8Jdony+KRbQ1v6vrxSbJEda6hFvs/6m8/K9x03YX6l1cBSw==" },
                new ApplicationUser { Firstname = "Guido",  Email = "user6@user.net",               UserName = "user6",         PasswordHash = "AERKKvjQxbgEBQJtyfc8Jdony+KRbQ1v6vrxSbJEda6hFvs/6m8/K9x03YX6l1cBSw==" }
            );
            */

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

        }
    }
}
