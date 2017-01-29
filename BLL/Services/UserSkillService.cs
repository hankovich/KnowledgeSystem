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
    public class UserSkillService : IUserSkillService
    {
        private readonly IUnitOfWork uow;
        private readonly IUserSkillRepository userSkillRepository;

        public UserSkillService(IUnitOfWork uow, IUserSkillRepository repository)
        {
            this.uow = uow;
            userSkillRepository = repository;
        }

        public UserSkillEntity GetUserSkillEntityById(int id) => userSkillRepository.GetById(id).ToBllUserSkill();

        public UserSkillEntity GetUserSkillEntityByPredicate(Expression<Func<UserSkillEntity, bool>> f)
        {
            //may contain some strange effect
            return userSkillRepository.GetAll().ToList().Select(userSkill => userSkill.ToBllUserSkill()).Where(f.Compile()).FirstOrDefault();
        }

        public IEnumerable<UserSkillEntity> GetAllUserSkillEntities() => userSkillRepository.GetAll().ToList().Select(userSkill => userSkill.ToBllUserSkill());

        public void CreateUserSkill(UserSkillEntity userSkillEntity)
        {
            userSkillRepository.Create(userSkillEntity.ToDalUserSkill());
            uow.Commit();
        }

        public void DeleteUserSkill(UserSkillEntity userSkillEntity)
        {
            userSkillRepository.Delete(userSkillEntity.ToDalUserSkill());
            uow.Commit();
        }

        public void UpdateUserSkill(UserSkillEntity userSkillEntity)
        {
            userSkillRepository.Update(userSkillEntity.ToDalUserSkill());
            uow.Commit();
        }


        public int GetLevelOfSkillForUserEntity(int userId, int skillId)
        {
            return userSkillRepository.GetLevelOfSkillForUser(userId, skillId);
        }
    }
}
