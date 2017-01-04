using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using TicketingSystem.Services;
using TicketingSystem.Models;
using TicketingSystem.Controllers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TicketingSystem
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IIssueService, IssueService>();
            container.RegisterType<IIssueReplyService, IssueReplyService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IApplicationDbContext, ApplicationDbContext>(new PerThreadLifetimeManager());
            container.RegisterType(typeof(IBaseService<>), typeof(BaseService<>));

            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}