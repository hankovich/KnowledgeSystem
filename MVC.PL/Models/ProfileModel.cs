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
        [StringLength(30, ErrorMessage = "The fisrt name must contain at least {2} characters and no more that 30 characters", MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The field can not be empty!")]
        [Display(Name = "Enter your last name")]
        [StringLength(30, ErrorMessage = "The last name must contain at least {2} characters and no more that 30 characters", MinimumLength = 3)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The field can not be empty!")]
        [Display(Name = "Enter your date of birth")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "The field can not be empty!")]
        [Display(Name = "Enter your place of work/study")]
        [StringLength(50, ErrorMessage = "The company name must contain at least {2} characters and no more that 50 characters", MinimumLength = 2)]
        public string Company { get; set; }

        [Required(ErrorMessage = "The field can not be empty!")]
        [Display(Name = "Enter your contact phone")]
        [RegularExpression(@"^\+[1-9]{1}[0-9]{3,14}$", ErrorMessage = "Phone is incorrect")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "The field can not be empty!")]
        [Display(Name = "Enter your city of residence")]
        [StringLength(20, ErrorMessage = "The login must contain at least {2} characters and no more that 20 characters", MinimumLength = 2)]
        public string City { get; set; }
    }
}