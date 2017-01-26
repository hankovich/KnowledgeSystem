using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class UserMapperBLL
    {
        public static DalUser ToDalUser(this UserEntity userEntity)
        {
           DalUser dalUser = new DalUser
            {
                id = userEntity.id,
                //City = userEntity.City,
                Email = userEntity.Email,
                Login = userEntity.Login,
                Password = userEntity.Password,
                /*Company = userEntity.Company,
                DateOfBirth = userEntity.DateOfBirth,
                FirstName = userEntity.FirstName,
                LastName = userEntity.LastName,
                Phone = userEntity.Phone*/
            };
            return dalUser;
        }

        public static UserEntity ToBllUser(this DalUser user)
        {
            if (user == null)
                return null;

            UserEntity ormUser = new UserEntity
            {
               // City = user.City,
                Email = user.Email,
                Login = user.Login,
                Password = user.Password,
                /*Company = user.Company,
                DateOfBirth = user.DateOfBirth,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.Phone*/
            };
            return ormUser;
        }
    }
}
