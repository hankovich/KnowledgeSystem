using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using ORM;

namespace DAL.Mappers
{
    public static class UserSkillMapper
    {
        public static DalUserSkill ToDalUserSkill(this UserSkill userSkill)
        {
            if (userSkill == null)
                return null;

            DalUserSkill dalUserSkill = new DalUserSkill
            {
                id = userSkill.id,
                SkillId = userSkill.SkillId,
                UserId = userSkill.UserId
            };

            return dalUserSkill;
        }

        public static UserSkill ToOrmUserSkill(this DalUserSkill dalUserSkill)
        {
            if (dalUserSkill == null)
                return null;

            UserSkill userSkill = new UserSkill
            {
                SkillId = dalUserSkill.SkillId,
                UserId = dalUserSkill.UserId
            };

            return userSkill;
        }
    }
}
