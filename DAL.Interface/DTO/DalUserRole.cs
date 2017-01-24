using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DalUserRole : IEntity
    {
        public int id { get; set; }

        public int RoleId { get; set; }

        public int UserId { get; set; }
    }
}
