﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TicketingSystem.Models;

namespace TicketingSystem.Services
{
    public interface IUserService
    {
        List<WebUser> AllUsers();

        WebUser GetUser(string id);

        string GetUserRole(string userName);
    }
}