using CalendarThematicPlan.BLL.Interface;
using CalendarThematicPlan.Container;
using Ninject;
using System;
using System.Web.Security;

namespace CalendarThematicPlan.WEB.Models
{
    public sealed class MyRoleProvider : RoleProvider
    {
        private static readonly IUserLogic userLogic;

        static MyRoleProvider()
        {
            userLogic = NinjectCommon.Kernel.Get<IUserLogic>();
        }
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

            var user = userLogic.GetUserByEmail(username);
            if (user != null)
            {
                switch (user.Role)
                {
                    case nameof(Roles.Admin):
                        return new[] { nameof(Roles.Admin), nameof(Roles.Moderator), nameof(Roles.User) };
                    case nameof(Roles.Moderator):
                        return new[] { nameof(Roles.Moderator), nameof(Roles.User) };
                    case nameof(Roles.User):
                        return new[] { nameof(Roles.User) };
                    case nameof(Roles.Stranger):
                        return new[] { nameof(Roles.Stranger) };
                }
            }

            return new[] { nameof(Roles.Stranger) };
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