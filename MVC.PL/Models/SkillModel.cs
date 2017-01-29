using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.PL.Models
{
    public class SkillModel
    {
        [Display(Name = "Skill Id")]
        public int Id { get; set; }

        [Display(Name = "Skill name")]
        public string Name { get; set; } 

        [Display(Name = "Skill level")]
        public int Level { get; set; }
    }
}