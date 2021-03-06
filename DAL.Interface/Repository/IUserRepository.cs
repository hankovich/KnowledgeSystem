﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;

namespace DAL.Interface.Repository
{
    public interface IUserRepository: IRepository<DalUser>
    {
        void AddRoleToUser(string login, string roleName);
        DalUser GetByEmail(string email);
        DalUser GetByLogin(string login);
        void RemoveRoleFromUser(int userId, int roleId);
        void RemoveAllRolesFromUser(int userId);
    }
}
