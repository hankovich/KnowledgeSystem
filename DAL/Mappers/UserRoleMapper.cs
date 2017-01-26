using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
//using ORM;
using ORMORM;

namespace DAL.Mappers
{
    public static class UserRoleMapper
    {
        public static DalUserRole ToDalUserRole(this UserRole userRole)
        {
            if (userRole == null)
                return null;

            DalUserRole dalUserRole = new DalUserRole
            {
                id = userRole.id,
                RoleId = userRole.RoleId,
                UserId = userRole.UserId
            };

            return dalUserRole;
        }

        public static UserRole ToOrmUserRole(this DalUserRole dalUserRole)
        {
           UserRole userRole = new UserRole
            {
                RoleId = dalUserRole.RoleId,
                UserId = dalUserRole.UserId
            };

            return userRole;
        }
    }
}
