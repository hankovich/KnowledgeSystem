using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class UserRoleMapperBLL
    {
        public static DalUserRole ToDalUserRole(this UserRoleEntity userRole)
        {
            DalUserRole dalUserRole = new DalUserRole
            {
                id = userRole.id,
                RoleId = userRole.RoleId,
                UserId = userRole.UserId
            };

            return dalUserRole;
        }

        public static UserRoleEntity ToBllUserRole(this DalUserRole dalUserRole)
        {
            if (dalUserRole == null)
                return null;

            UserRoleEntity userRole = new UserRoleEntity
            {
                id = dalUserRole.id,
                RoleId = dalUserRole.RoleId,
                UserId = dalUserRole.UserId
            };

            return userRole;
        }
    }
}
