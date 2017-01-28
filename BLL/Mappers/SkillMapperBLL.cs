using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class SkillMapperBLL
    {
        public static DalSkill ToDalSkill(this SkillEntity skill)
        {
            DalSkill dalSkill = new DalSkill
            {
                id = skill.id,
                SkillCategoryId = skill.SkillCategoryId,
                SkillName = skill.SkillName
            };

            return dalSkill;
        }

        public static SkillEntity ToBllSkill(this DalSkill skill)
        {
            if (skill == null)
                return null;

            SkillEntity ormSkill = new SkillEntity
            {
                id = skill.id,
                SkillCategoryId = skill.SkillCategoryId,
                SkillName = skill.SkillName
            };

            return ormSkill;
        }
    }
}
