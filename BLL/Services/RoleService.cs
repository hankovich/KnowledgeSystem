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
    public class RoleService: IRoleService
    {
        private readonly IUnitOfWork uow;
        private readonly IRoleRepository roleRepository;

        public RoleService(IUnitOfWork uow, IRoleRepository repository)
        {
            this.uow = uow;
            roleRepository = repository;
        }

        public IEnumerable<RoleEntity> GetAllRoleEntities() => roleRepository.GetAll().ToList().Select(role => role.ToBllRole());

        public RoleEntity GetRoleEntityById(int key) => roleRepository.GetById(key).ToBllRole();

        public RoleEntity GetRoleEntityByPredicate(Expression<Func<RoleEntity, bool>> f)
        {
            //may contain some strange effect
            return roleRepository.GetAll().ToList().Select(role => role.ToBllRole()).Where(f.Compile()).FirstOrDefault();
        }

        public void CreateRole(RoleEntity roleEntity)
        {
            roleRepository.Create(roleEntity.ToDalRole());
            uow.Commit();
        }

        public void DeleteRole(RoleEntity roleEntity)
        {
            roleRepository.Delete(roleEntity.ToDalRole());
            uow.Commit();
        }

        public void UpdateRole(RoleEntity roleEntity)
        {
            roleRepository.Update(roleEntity.ToDalRole());
            uow.Commit();
        }

        public RoleEntity GetRoleEntityByName(string roleName) => roleRepository.GetRoleByName(roleName).ToBllRole();

        public IEnumerable<RoleEntity> GetRoleEntitiesOfUser(int userId) => roleRepository.GetRolesOfUser(userId).Select(role => role.ToBllRole());
    }
}
