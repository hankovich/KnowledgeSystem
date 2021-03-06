﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IUserService
    {
        UserEntity GetUserEntityById(int id);
        UserEntity GetUserEntityByEmail(string email);
        UserEntity GetUserEntityByLogin(string login);
        UserEntity GetUserEntityByPredicate(Expression<Func<UserEntity, bool>> f);
        IEnumerable<UserEntity> GetAllUserEntities();
        void CreateUser(UserEntity userEntity);
        void DeleteUser(UserEntity userEntity);
        void UpdateUser(UserEntity userEntity);
        void AddRoleToUser(string login, string roleName);

        void RemoveRoleFromUser(int userId, int roleId);
        void RemoveAllRolesFromUser(int userId);
    }
}
