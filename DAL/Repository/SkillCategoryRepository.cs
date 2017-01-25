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
    public class SkillCategoryRepository: ISkillCategoryRepository
    {
        private readonly DbContext context;

        public SkillCategoryRepository(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<DalSkillCategory> GetAll() => context.Set<SkillCategory>().ToList().Select(skillCategory => skillCategory.ToDalSkillCategory());

        public DalSkillCategory GetById(int key) => context.Set<SkillCategory>().FirstOrDefault(skill => skill.id == key)?.ToDalSkillCategory();

        public DalSkillCategory GetByPredicate(Expression<Func<DalSkillCategory, bool>> f) => context.Set<SkillCategory>().Select(skillCategory => skillCategory.ToDalSkillCategory()).Where(f).FirstOrDefault();

        public void Create(DalSkillCategory e) => context.Set<SkillCategory>().Add(e.ToOrmSkillCategory());

        public void Delete(DalSkillCategory e)
        {
            var skillCategory = context.Set<SkillCategory>().FirstOrDefault(n => n.id == e.id);
            context.Set<SkillCategory>().Remove(skillCategory);
        }

        public void Update(DalSkillCategory entity)
        {
            var skillCategory = context.Set<SkillCategory>().FirstOrDefault(n => n.id == entity.id);
            if (skillCategory != null)
            {
                skillCategory.Name = entity.Name;
            }
        }

        public DalSkillCategory GetByName(string categoryName)
        {
            return context.Set<SkillCategory>().ToList().FirstOrDefault(skillCategory => skillCategory.Name == categoryName).ToDalSkillCategory();
        }
    }
}
