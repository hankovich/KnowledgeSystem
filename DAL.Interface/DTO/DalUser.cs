using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DalUser : IEntity
    {
        public int id { get; set; }
        
        public string Login { get; set; }
        
        public string Email { get; set; }
        
        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Company { get; set; }

        public string Phone { get; set; }

        public string City { get; set; }
    }
}
