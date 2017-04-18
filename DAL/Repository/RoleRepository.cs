using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using DAL.Mappers;
using ORM;

namespace DAL.Repository
{
    public class RoleRepository: IRoleRepository
    {
        private readonly DbContext context;

        public RoleRepository(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<DalRole> GetAll() => context.Set<Role>().ToList().Select(user => user.ToDalRole());

        public DalRole GetById(int key) => context.Set<Role>().FirstOrDefault(user => user.id == key)?.ToDalRole();

        public DalRole GetByPredicate(Expression<Func<DalRole, bool>> f) => context.Set<Role>().Select(role => role.ToDalRole()).Where(f).FirstOrDefault();

        public void Create(DalRole e) => context.Set<Role>().Add(e.ToOrmRole());

        public void Delete(DalRole e)
        {
            var role = context.Set<Role>().FirstOrDefault(n => n.id == e.id);
            context.Set<Role>().Remove(role);
        }

        public void Update(DalRole entity)
        {
            var role = context.Set<Role>().FirstOrDefault(n => n.id == entity.id);
            if (role != null)
            {
                role.Name = entity.Name;
            }
        }

        public DalRole GetRoleByName(string roleName) => context.Set<Role>().FirstOrDefault(role => role.Name == roleName)?.ToDalRole();

        public IEnumerable<DalRole> GetRolesOfUser(int userId)
        {
            var roleIds = context.Set<UserRole>().ToList().Where(roleUser => roleUser.UserId == userId).Select(roleUser => roleUser.RoleId).ToList();
            return roleIds.Select(id => context.Set<Role>().ToList().FirstOrDefault(role => role.id == id).ToDalRole());

            //var roleIds = context.Set<UserRole>().Where(roleUser => roleUser.UserId == userId).Select(roleUser => roleUser.RoleId);

            //foreach (var roleId in roleIds)
            //    yield return context.Set<Role>().ToList().FirstOrDefault(role => role.id == roleId).ToDalRole();
        }
    }
}
