namespace ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserSkill")]
    public partial class UserSkill
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int UserId { get; set; }

        public int SkillId { get; set; }

        public int SkillLevel { get; set; }

        public virtual Skill Skill { get; set; }
    }
}
