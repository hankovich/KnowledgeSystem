using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using ORM;

namespace DAL.Mappers
{
    public static class SkillCategoryMapper
    {
        public static DalSkillCategory ToDalSkillCategory(this SkillCategory skillCategory)
        {
            if (skillCategory == null)
                return null;
            DalSkillCategory dalSkillCategory = new DalSkillCategory
            {
                id = skillCategory.id,
                Name = skillCategory.Name
            };

            return dalSkillCategory;
        }

        public static SkillCategory ToOrmSkillCategory(this DalSkillCategory dalSkillCategory)
        {
            SkillCategory skillCategory = new SkillCategory
            {
                Name = dalSkillCategory.Name
            };

            return skillCategory;
        }
    }
}
