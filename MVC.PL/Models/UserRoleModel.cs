using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.PL.Models
{
    public class UserRoleModel
    {
        public int id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; set; }
        public IEnumerable<string> AllRoles { get; set; }
    }
}