using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class SkillEntity
    {
        public int id { get; set; }

        public int SkillCategoryId { get; set; }

        public string SkillName { get; set; }

        public int SkillLevel { get; set; }
    }
}
