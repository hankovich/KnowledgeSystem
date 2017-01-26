namespace ORMORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public int Id { get; set; }

        [StringLength(30)]
        public string Login { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        [StringLength(256)]
        public string Password { get; set; }
    }
}
