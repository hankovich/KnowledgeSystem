using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using ORM;

namespace DAL.Mappers
{
    public static class SkillMapper
    {
        public static DalSkill ToDalSkill(this Skill skill)
        {
            if (skill == null)
                return null;

            DalSkill dalSkill = new DalSkill
            {
                id = skill.id,
                SkillCategoryId = skill.SkillCategoryId,
                SkillName = skill.SkillName
            };

            return dalSkill;
        }

        public static Skill ToOrmSkill(this DalSkill skill)
        {
            Skill ormSkill = new Skill
            {
                SkillCategoryId = skill.SkillCategoryId,
                SkillName = skill.SkillName
            };

            return ormSkill;
        }
    }
}
