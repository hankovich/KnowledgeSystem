using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interface.Entities;

namespace MVC.PL.Models
{
    public class AdminModel
    {
        public IEnumerable<UserRoleModel> userRole;
        public IEnumerable<SkillCategoryModel> skills;
        public IEnumerable<UserSkillEntity> userSkills;
    }
}