using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DalUserSkill : IEntity
    {
        public int id { get; set; }

        public int UserId { get; set; }

        public int SkillId { get; set; }
    }
}
