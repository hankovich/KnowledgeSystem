using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DalSkill : IEntity
    {
        public int id { get; set; }

        public int SkillCategoryId { get; set; }

        public string SkillName { get; set; }
    }
}
