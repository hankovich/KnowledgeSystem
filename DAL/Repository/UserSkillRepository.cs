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
    public class UserSkillRepository : IUserSkillRepository
    {
        private readonly DbContext context;

        public UserSkillRepository(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<DalUserSkill> GetAll() => context.Set<UserSkill>().ToList().Select(skill => skill.ToDalUserSkill());

        public DalUserSkill GetById(int key) => context.Set<UserSkill>().FirstOrDefault(userSkill => userSkill.id == key)?.ToDalUserSkill();

        public DalUserSkill GetByPredicate(Expression<Func<DalUserSkill, bool>> f) => context.Set<UserSkill>().Select(userSkill => userSkill.ToDalUserSkill()).Where(f).FirstOrDefault();

        public void Create(DalUserSkill e) => context.Set<UserSkill>().Add(e.ToOrmUserSkill());

        public void Delete(DalUserSkill e)
        {
            var skill = context.Set<UserSkill>().FirstOrDefault(n => n.id == e.id);
            context.Set<UserSkill>().Remove(skill);
        }

        public void Update(DalUserSkill entity)
        {
            var userSkill = context.Set<UserSkill>().FirstOrDefault(n => n.id == entity.id);
            if (userSkill != null)
            {
                userSkill.SkillId = entity.SkillId;
                userSkill.UserId = entity.UserId;
                userSkill.SkillLevel = entity.SkillLevel;
            }
        }

        public int GetLevelOfSkillForUser(int userId, int skillId)
        {
            return context.Set<UserSkill>()
                .FirstOrDefault(userSkill => userSkill.SkillId == skillId && userSkill.UserId == userId)?
                .SkillLevel ?? 0;
        }
    }
}
