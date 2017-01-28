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
    public class SkillRepository : ISkillRepository
    {
        private readonly DbContext context;

        public SkillRepository(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<DalSkill> GetAll() => context.Set<Skill>().ToList().Select(skill => skill.ToDalSkill());

        public DalSkill GetById(int key) => context.Set<Skill>().FirstOrDefault(skill => skill.id == key)?.ToDalSkill();

        public DalSkill GetByPredicate(Expression<Func<DalSkill, bool>> f) => context.Set<Skill>().Select(skill => skill.ToDalSkill()).Where(f).FirstOrDefault();

        public void Create(DalSkill e) => context.Set<Skill>().Add(e.ToOrmSkill());

        public void Delete(DalSkill e)
        {
            var skill = context.Set<Skill>().FirstOrDefault(n => n.id == e.id);
            context.Set<Skill>().Remove(skill);
        }

        public void Update(DalSkill entity)
        {
            var skill = context.Set<Skill>().FirstOrDefault(n => n.id == entity.id);
            if (skill != null)
            {
                skill.SkillCategoryId = entity.SkillCategoryId;
                skill.SkillName = entity.SkillName;
            }
        }

        public IEnumerable<DalSkill> GetAllForUser(int userId)
        {
            var skillIds = context.Set<UserSkill>().Where(userSkill => userSkill.UserId == userId).Select(userSkill => userSkill.SkillId);
            foreach (var roleId in skillIds)
                yield return context.Set<Skill>().ToList().FirstOrDefault(role => role.id == roleId).ToDalSkill();
        }

        public IEnumerable<DalSkill> GetAllForCategory(int categoryId)
            =>
                context.Set<Skill>()
                    .ToList()
                    .Where(skill => skill.SkillCategoryId == categoryId)
                    .Select(skill => skill.ToDalSkill());

        //{
        //  yield return context.Set<Skill>().ToList().FirstOrDefault(skill => skill.SkillCategoryId == categoryId).ToDalSkill();
        //}
    }
}
