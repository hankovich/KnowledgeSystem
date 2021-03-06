﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface ISkillService
    {
        SkillEntity GetSkillEntityById(int id);
        SkillEntity GetSkillEntityByPredicate(Expression<Func<SkillEntity, bool>> f);
        IEnumerable<SkillEntity> GetAllSkillEntities();
        void CreateSkill(SkillEntity skillEntity);
        void DeleteSkill(SkillEntity skillEntity);
        void UpdateSkill(SkillEntity skillEntity);
        IEnumerable<SkillEntity> GetAllSkillEntitiesForUser(int userId);
        IEnumerable<SkillEntity> GetAllSkillEntitiesForCategory(int categoryId);
    }
}
