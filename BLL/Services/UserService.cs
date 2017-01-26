using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Repository;

namespace BLL.Services
{
    public class UserService: IUserService
    {
        private readonly IUnitOfWork uow;
        private readonly IUserRepository userRepository;

        public UserService(IUnitOfWork uow, IUserRepository repository)
        {
            this.uow = uow;
            userRepository = repository;
        }

        public UserEntity GetUserEntityById(int id) => userRepository.GetById(id).ToBllUser();

        public UserEntity GetUserEntityByEmail(string email) => userRepository.GetByEmail(email).ToBllUser();

        public UserEntity GetUserEntityByLogin(string login) => userRepository.GetByLogin(login).ToBllUser();

        public UserEntity GetUserEntityByPredicate(Expression<Func<UserEntity, bool>> f)
        {
            //may contain some strange effect
            return userRepository.GetAll().ToList().Select(user => user.ToBllUser()).Where(f.Compile()).FirstOrDefault();
        }

        public IEnumerable<UserEntity> GetAllUserEntities() => userRepository.GetAll().ToList().Select(user => user.ToBllUser());

        public void CreateUser(UserEntity userEntity)
        {
            userRepository.Create(userEntity.ToDalUser());
            uow.Commit();
        }

        public void DeleteUser(UserEntity userEntity)
        {
            userRepository.Delete(userEntity.ToDalUser());
            uow.Commit();
        }

        public void UpdateUser(UserEntity userEntity)
        {
            userRepository.Update(userEntity.ToDalUser());
            uow.Commit();
        }

        public void AddRoleToUser(string login, string roleName)
        {
            userRepository.AddRoleToUser(login, roleName);
            uow.Commit();
        }
    }
}
