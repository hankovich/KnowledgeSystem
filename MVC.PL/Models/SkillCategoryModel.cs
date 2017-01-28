using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.PL.Models
{
    public class SkillCategoryModel
    {
        [Display(Name = "Skill Category Id")]
        public int Id { get; set; }

        [Display(Name = "Skill Category name")]
        public string Name { get; set; }

        [Display(Name = "Skills in category")]
        public IEnumerable<SkillModel> Skills { get; set; }
    }
}