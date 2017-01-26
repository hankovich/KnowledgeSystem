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
using ORMORM;

//using ORM;

namespace DAL.Repository
{
    public class UserRepository: IUserRepository
    {
        private readonly DbContext context;

        public UserRepository(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<DalUser> GetAll() => context.Set<User>().ToList().Select(user => user.ToDalUser());

        public DalUser GetById(int key) => context.Set<User>().FirstOrDefault(user => user.Id == key)?.ToDalUser();

        public DalUser GetByPredicate(Expression<Func<DalUser, bool>> f) => context.Set<User>().Select(user => user.ToDalUser()).Where(f).FirstOrDefault();

        public void Create(DalUser e) => context.Set<User>().Add(e.ToOrmUser());

        public void Delete(DalUser e)
        {
            var user = context.Set<User>().FirstOrDefault(n => n.Id == e.id);
            context.Set<User>().Remove(user);
        }

        public void Update(DalUser entity)
        {
            var user = context.Set<User>().FirstOrDefault(n => n.Id == entity.id);
            if (user != null)
            {
                /*user.City = entity.City;
                user.Company = entity.Company;
                user.DateOfBirth = entity.DateOfBirth;
                user.FirstName = entity.FirstName;
                user.LastName = entity.LastName;
                user.Phone = entity.Phone;
                */user.Email = entity.Email;
                user.Login = entity.Login;
                user.Password = entity.Password;
            }
        }

        public void AddRoleToUser(string login, string roleName)
        {
            var nessesaryRole = context.Set<Role>().FirstOrDefault(role => role.Name == roleName);
            var nessesaryUser = context.Set<User>().FirstOrDefault(user => user.Login == login);
            UserRole userRole = new UserRole
            {
                RoleId = nessesaryRole.id, //    NRE
                UserId = nessesaryUser.Id  //    NRE
            };
            context.Set<UserRole>().Add(userRole);
        }

        public DalUser GetByEmail(string email) => context.Set<User>().FirstOrDefault(n => n.Email == email)?.ToDalUser();

        public DalUser GetByLogin(string login) => context.Set<User>().FirstOrDefault(n => n.Login == login)?.ToDalUser();
    }
}
