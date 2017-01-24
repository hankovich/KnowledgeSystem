using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using ORM;

namespace DAL.Mappers
{
    public static class RoleMapper
    {
        public static DalRole ToDalRole(this Role user)
        {
            if (user == null)
                return null;

            DalRole dalRole = new DalRole
            {
                id = user.id,
                Name = user.Name
            };
            return dalRole;
        }

        public static Role ToOrmRole(this DalRole user)
        {
            if (user == null)
                return null;

            Role ormRole = new Role
            {
                Name = user.Name
            };
            return ormRole;
        }

    }
}
