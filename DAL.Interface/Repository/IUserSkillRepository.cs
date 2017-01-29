using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;

namespace DAL.Interface.Repository
{
    public interface IUserSkillRepository : IRepository<DalUserSkill>
    {
        int GetLevelOfSkillForUser(int userId, int skillId);
        void RemoveSkillFromUser(int userId, int skillId);
        void RemoveAllUserSkills(int userId);
    }
}
