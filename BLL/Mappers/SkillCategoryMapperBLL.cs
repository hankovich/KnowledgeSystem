using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class SkillCategoryMapperBLL
    {
        public static DalSkillCategory ToDalSkillCategory(this SkillCategoryEntity skillCategory)
        {
            DalSkillCategory dalSkillCategory = new DalSkillCategory
            {
                id = skillCategory.id,
                Name = skillCategory.Name
            };

            return dalSkillCategory;
        }

        public static SkillCategoryEntity ToBllSkillCategory(this DalSkillCategory dalSkillCategory)
        {
            if (dalSkillCategory == null)
                return null;

            SkillCategoryEntity skillCategory = new SkillCategoryEntity
            {
                Name = dalSkillCategory.Name
            };

            return skillCategory;
        }
    }
}
