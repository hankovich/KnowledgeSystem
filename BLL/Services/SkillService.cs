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
    public class SkillService: ISkillService
    {
        private readonly IUnitOfWork uow;
        private readonly ISkillRepository skillRepository;

        public SkillService(IUnitOfWork uow, ISkillRepository repository)
        {
            this.uow = uow;
            skillRepository = repository;
        }

        public SkillEntity GetSkillEntityById(int id) => skillRepository.GetById(id).ToBllSkill();

        public SkillEntity GetSkillEntityByPredicate(Expression<Func<SkillEntity, bool>> f)
        {
            //may contain some strange effect
            return skillRepository.GetAll().ToList().Select(skill => skill.ToBllSkill()).Where(f.Compile()).FirstOrDefault();
        }

        public IEnumerable<SkillEntity> GetAllSkillEntities() => skillRepository.GetAll().ToList().Select(skill => skill.ToBllSkill());

        public void CreateSkill(SkillEntity skillEntity)
        {
            skillRepository.Create(skillEntity.ToDalSkill());
            uow.Commit();
        }

        public void DeleteSkill(SkillEntity skillEntity)
        {
            skillRepository.Delete(skillEntity.ToDalSkill());
            uow.Commit();
        }

        public void UpdateSkill(SkillEntity skillEntity)
        {
            skillRepository.Update(skillEntity.ToDalSkill());
            uow.Commit();
        }

        public IEnumerable<SkillEntity> GetAllSkillEntitiesForUser(int userId) => skillRepository.GetAllForUser(userId).Select(skill => skill.ToBllSkill());

        public IEnumerable<SkillEntity> GetAllSkillEntitiesForCategory(int categoryId) => skillRepository.GetAllForCategory(categoryId).Select(skill => skill.ToBllSkill());
    }
}
