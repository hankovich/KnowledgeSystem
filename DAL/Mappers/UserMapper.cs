using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using ORM;

namespace DAL.Mappers
{
    public static class UserMapper
    {
        public static DalUser ToDalUser(this User user)
        {
            if (user == null)
                return null;

            DalUser dalUser = new DalUser
            {
                id = user.id,
                City = user.City,
                Email = user.Email,
                Login = user.Login,
                Password = user.Password,
                Company = user.Company,
                DateOfBirth = user.DateOfBirth,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.Phone
            };
            return dalUser;
        }

        public static User ToOrmUser(this DalUser user)
        {
            //NULLNULLNULLNULL

            User ormUser = new User
            { 
                City = user.City,
                Email = user.Email,
                Login = user.Login,
                Password = user.Password,
                Company = user.Company,
                DateOfBirth = user.DateOfBirth,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.Phone
            };
            return ormUser;
        }
    }
}
