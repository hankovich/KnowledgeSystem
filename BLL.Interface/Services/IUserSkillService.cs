using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IUserSkillService
    {
        UserSkillEntity GetUserSkillEntityById(int id);
        UserSkillEntity GetUserSkillEntityByPredicate(Expression<Func<UserSkillEntity, bool>> f);
        IEnumerable<UserSkillEntity> GetAllUserSkillEntities();
        void CreateUserSkill(UserSkillEntity skillCategoryEntity);
        void DeleteUserSkill(UserSkillEntity skillCategoryEntity);
        void UpdateUserSkill(UserSkillEntity skillCategoryEntity);
        int GetLevelOfSkillForUserEntity(int userId, int skillId);

        void RemoveSkillFromUser(int userId, int skillId);
        void RemoveAllUserSkills(int userId);
    }
}
