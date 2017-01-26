using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IRoleService
    {
        IEnumerable<RoleEntity> GetAllRoleEntities();
        RoleEntity GetRoleEntityById(int key);
        RoleEntity GetRoleEntityByPredicate(Expression<Func<RoleEntity, bool>> f);
        void CreateRole(RoleEntity roleEntity);
        void DeleteRole(RoleEntity roleEntity);
        void UpdateRole(RoleEntity roleEntity);
        RoleEntity GetRoleEntityByName(string roleName);
        IEnumerable<RoleEntity> GetRoleEntitiesOfUser(int userId);
    }
}
