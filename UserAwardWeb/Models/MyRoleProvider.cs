﻿using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using UserAward.BLL.Interface;
using UserAward.Container;

namespace UserAwardWeb.Models
{
    public class MyRoleProvider : RoleProvider
    {
        private readonly IAccountLogic accountLogic = NinjectCommon.Kernel.Get<IAccountLogic>();
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            if (username == "admin")
            {
                return new[] { "Admin", "User" };
            }

            var account = accountLogic.GetAccountByEmail(username);
            if (account != null)
            {
                switch (account.Role)
                {
                    case "User":
                        return new[] { "User" };
                    case "Admin":
                        return new[] { "Admin", "User" };
                    default:
                        return new string[] { "Stranger" };
                }
            }

            return new string[] { };
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}