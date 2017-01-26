using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface ISkillCategoryService
    {
        SkillCategoryEntity GetSkillCategoryEntityById(int id);
        SkillCategoryEntity GetSkillCategoryEntityByPredicate(Expression<Func<SkillCategoryEntity, bool>> f);
        IEnumerable<SkillCategoryEntity> GetAllSkillCategoryEntities();
        void CreateSkillCategory(SkillCategoryEntity skillCategoryEntity);
        void DeleteSkillCategory(SkillCategoryEntity skillCategoryEntity);
        void UpdateSkillCategory(SkillCategoryEntity skillCategoryEntity);
        SkillCategoryEntity GetSkillCategoryEntityByName(string categoryName);
    }
}
