using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetHospital.BusinessLogic.Models
{
    public class UserRegistrationModel
    {
        [Required]
        public string UserName { get; set; }
        //[Required]
        public string FirstName { get; set; }
        //[Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords are different")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*\W)(?!.*\s).{8,24}$", ErrorMessage = "Password must be at least 8 characters and contain digits, upper and lower case and non alphanumeric symbols")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Role { get; set; }  // doctor or patient (on Angular make method that assign the string value depending of user choice
        public string Status { get; set; }
    }
}
