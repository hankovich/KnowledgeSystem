using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace MVC.PL.Models
{
    public class ManagerModel
    {
        public IEnumerable<SkillCategoryModel> SkillCategory { get; set; }
        public IEnumerable<ProfileModel> Users { get; set; }
    }
}