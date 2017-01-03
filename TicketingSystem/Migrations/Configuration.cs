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
            /*
            context.Users.AddOrUpdate(
                new ApplicationUser { Email = "admin@company.net",          UserName = "admin",         PasswordHash = "AERKKvjQxbgEBQJtyfc8Jdony+KRbQ1v6vrxSbJEda6hFvs/6m8/K9x03YX6l1cBSw==", SecurityStamp = "AERKKvjQxbgEBQJtyfc8J" },
                new ApplicationUser { Email = "dispatcher@company.net",     UserName = "dispatcher",    PasswordHash = "AERKKvjQxbgEBQJtyfc8Jdony+KRbQ1v6vrxSbJEda6hFvs/6m8/K9x03YX6l1cBSw==", SecurityStamp = "AERKKvjQxbgEBQJtyfc8J" },
                new ApplicationUser { Email = "solver1@company.net",        UserName = "solver1",       PasswordHash = "AERKKvjQxbgEBQJtyfc8Jdony+KRbQ1v6vrxSbJEda6hFvs/6m8/K9x03YX6l1cBSw==", SecurityStamp = "AERKKvjQxbgEBQJtyfc8J" },
                new ApplicationUser { Email = "solver2@company.net",        UserName = "solver2",       PasswordHash = "AERKKvjQxbgEBQJtyfc8Jdony+KRbQ1v6vrxSbJEda6hFvs/6m8/K9x03YX6l1cBSw==", SecurityStamp = "AERKKvjQxbgEBQJtyfc8J" },
                new ApplicationUser { Email = "manager1@company.net",       UserName = "manager1",      PasswordHash = "AERKKvjQxbgEBQJtyfc8Jdony+KRbQ1v6vrxSbJEda6hFvs/6m8/K9x03YX6l1cBSw==", SecurityStamp = "AERKKvjQxbgEBQJtyfc8J" },
                new ApplicationUser { Email = "manager2@company.net",       UserName = "manager2",      PasswordHash = "AERKKvjQxbgEBQJtyfc8Jdony+KRbQ1v6vrxSbJEda6hFvs/6m8/K9x03YX6l1cBSw==", SecurityStamp = "AERKKvjQxbgEBQJtyfc8J" },
                new ApplicationUser { Email = "manager3@company.net",       UserName = "manager3",      PasswordHash = "AERKKvjQxbgEBQJtyfc8Jdony+KRbQ1v6vrxSbJEda6hFvs/6m8/K9x03YX6l1cBSw==", SecurityStamp = "AERKKvjQxbgEBQJtyfc8J" },
                new ApplicationUser { Email = "user1@company.net",          UserName = "user1",         PasswordHash = "AERKKvjQxbgEBQJtyfc8Jdony+KRbQ1v6vrxSbJEda6hFvs/6m8/K9x03YX6l1cBSw==", SecurityStamp = "AERKKvjQxbgEBQJtyfc8J" },
                new ApplicationUser { Email = "user2@company.net",          UserName = "user2",         PasswordHash = "AERKKvjQxbgEBQJtyfc8Jdony+KRbQ1v6vrxSbJEda6hFvs/6m8/K9x03YX6l1cBSw==", SecurityStamp = "AERKKvjQxbgEBQJtyfc8J" },
                new ApplicationUser { Email = "user3@company.net",          UserName = "user3",         PasswordHash = "AERKKvjQxbgEBQJtyfc8Jdony+KRbQ1v6vrxSbJEda6hFvs/6m8/K9x03YX6l1cBSw==", SecurityStamp = "AERKKvjQxbgEBQJtyfc8J" },
                new ApplicationUser { Email = "user4@company.net",          UserName = "user4",         PasswordHash = "AERKKvjQxbgEBQJtyfc8Jdony+KRbQ1v6vrxSbJEda6hFvs/6m8/K9x03YX6l1cBSw==", SecurityStamp = "AERKKvjQxbgEBQJtyfc8J" },
                new ApplicationUser { Email = "user5@company.net",          UserName = "user5",         PasswordHash = "AERKKvjQxbgEBQJtyfc8Jdony+KRbQ1v6vrxSbJEda6hFvs/6m8/K9x03YX6l1cBSw==", SecurityStamp = "AERKKvjQxbgEBQJtyfc8J" },
                new ApplicationUser { Email = "user6@company.net",          UserName = "user6",         PasswordHash = "AERKKvjQxbgEBQJtyfc8Jdony+KRbQ1v6vrxSbJEda6hFvs/6m8/K9x03YX6l1cBSw==", SecurityStamp = "AERKKvjQxbgEBQJtyfc8J" }
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
