using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class UserSkillMapperBLL
    {
        public static DalUserSkill ToDalUserSkill(this UserSkillEntity userSkill)
        {
            DalUserSkill dalUserSkill = new DalUserSkill
            {
                id = userSkill.id,
                SkillId = userSkill.SkillId,
                UserId = userSkill.UserId
            };

            return dalUserSkill;
        }

        public static UserSkillEntity ToBllUserSkill(this DalUserSkill dalUserSkill)
        {
            if (dalUserSkill == null)
                return null;

            UserSkillEntity userSkill = new UserSkillEntity
            {
                SkillId = dalUserSkill.SkillId,
                UserId = dalUserSkill.UserId
            };

            return userSkill;
        }
    }
}
