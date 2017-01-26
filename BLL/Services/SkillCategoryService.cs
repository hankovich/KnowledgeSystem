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
    public class SkillCategoryService : ISkillCategoryService
    {
        private readonly IUnitOfWork uow;
        private readonly ISkillCategoryRepository skillCategoryRepository;

        public SkillCategoryService(IUnitOfWork uow, ISkillCategoryRepository repository)
        {
            this.uow = uow;
            skillCategoryRepository = repository;
        }

        public SkillCategoryEntity GetSkillCategoryEntityById(int id) => skillCategoryRepository.GetById(id).ToBllSkillCategory();

        public SkillCategoryEntity GetSkillCategoryEntityByPredicate(Expression<Func<SkillCategoryEntity, bool>> f)
        {
            //may contain some strange effect
            return skillCategoryRepository.GetAll().ToList().Select(skillCategory => skillCategory.ToBllSkillCategory()).Where(f.Compile()).FirstOrDefault();
        }

        public IEnumerable<SkillCategoryEntity> GetAllSkillCategoryEntities() => skillCategoryRepository.GetAll().ToList().Select(skillCategory => skillCategory.ToBllSkillCategory());

        public void CreateSkillCategory(SkillCategoryEntity skillCategoryEntity)
        {
            skillCategoryRepository.Create(skillCategoryEntity.ToDalSkillCategory());
            uow.Commit();
        }

        public void DeleteSkillCategory(SkillCategoryEntity skillCategoryEntity)
        {
            skillCategoryRepository.Delete(skillCategoryEntity.ToDalSkillCategory());
            uow.Commit();
        }

        public void UpdateSkillCategory(SkillCategoryEntity skillCategoryEntity)
        {
            skillCategoryRepository.Update(skillCategoryEntity.ToDalSkillCategory());
            uow.Commit();
        }

        public SkillCategoryEntity GetSkillCategoryEntityByName(string categoryName) => skillCategoryRepository.GetByName(categoryName).ToBllSkillCategory();
    }
}
