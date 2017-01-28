using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class RoleMapperBLL
    {
        public static DalRole ToDalRole(this RoleEntity user)
        {
            DalRole dalRole = new DalRole
            {
                id = user.id,
                Name = user.Name
            };
            return dalRole;
        }

        public static RoleEntity ToBllRole(this DalRole user)
        {
            if (user == null)
                return null;

            RoleEntity ormRole = new RoleEntity
            {
                id = user.id,
                Name = user.Name
            };
            return ormRole;
        }
    }
}
