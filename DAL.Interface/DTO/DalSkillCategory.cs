﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DalSkillCategory : IEntity
    {
        public int id { get; set; }

        public string Name { get; set; }
    }
}
