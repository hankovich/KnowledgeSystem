using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using BLL.Interface.Entities;
using BLL.Interface.Services;

namespace MVC.PL.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        public IUserService UserService
           => (IUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService));

        public IRoleService RoleService
            => (IRoleService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IRoleService));

        public override bool IsUserInRole(string login, string roleName)
        {
            UserEntity user = UserService.GetUserEntityByLogin(login);

            if (user == null) return false;

            var userRoles = RoleService.GetRoleEntitiesOfUser(user.id).ToList();

            if (userRoles.Any(v => v.Name.Contains(roleName)))
                return true;

            if (userRoles.Any(role => role.Name == roleName))
                return true;

            return false;
        }

        public override string[] GetRolesForUser(string login)
        {
            UserEntity user = UserService.GetUserEntityByLogin(login);
            if (user != null)
            {
                var userRoles = RoleService.GetRoleEntitiesOfUser(user.id).ToList().Select(role => role.Name).ToList();
                var r = userRoles.ToArray();
                return r;
            }
            return null;
        }

        public override void CreateRole(string roleName)
        {
            var newRole = new RoleEntity() { Name = roleName };
            RoleService.CreateRole(newRole);
        }
        #region stabs
        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
        #endregion
    }
}