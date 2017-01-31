using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.PL.Models
{
    public class ProfileModel
    {
        [ScaffoldColumn(false)]
        public int id { get; set; }

        [Required(ErrorMessage = "The field can not be empty!")]
        [Display(Name = "Enter your first name")]
        [StringLength(30,
            ErrorMessage = "The fisrt name must contain at least {2} characters and no more that 30 characters",
            MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The field can not be empty!")]
        [Display(Name = "Enter your last name")]
        [StringLength(30,
            ErrorMessage = "The last name must contain at least {2} characters and no more that 30 characters",
            MinimumLength = 3)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The field can not be empty!")]
        [Display(Name = "Enter your date of birth")]
        [RegularExpression(
            @"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]|(?:Jan|Mar|May|Jul|Aug|Oct|Dec)))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2]|(?:Jan|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec))\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)(?:0?2|(?:Feb))\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9]|(?:Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep))|(?:1[0-2]|(?:Oct|Nov|Dec)))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$",
            ErrorMessage = "Invalid Date")]
        //[DataType(DataType.Date)]
        //public DateTime? DateOfBirth { get; set; }
        public string DateOfBirth { get; set; }

        [Required(ErrorMessage = "The field can not be empty!")]
        [Display(Name = "Enter your place of work/study")]
        [StringLength(50,
            ErrorMessage = "The company name must contain at least {2} characters and no more that 50 characters",
            MinimumLength = 2)]
        public string Company { get; set; }

        [Required(ErrorMessage = "The field can not be empty!")]
        [Display(Name = "Enter your contact phone")]
        [RegularExpression(@"^\+[1-9]{1}[0-9]{3,14}$", ErrorMessage = "Phone is incorrect")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "The field can not be empty!")]
        [Display(Name = "Enter your city of residence")]
        [StringLength(20, ErrorMessage = "The login must contain at least {2} characters and no more that 20 characters",
            MinimumLength = 2)]
        public string City { get; set; }

        //
        public string Email { get; set; }
        public string Login { get; set; }
    }
}