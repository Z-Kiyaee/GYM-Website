using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UserRegisterDTO
    {
        [Required(ErrorMessage ="Your name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Your phone number is required")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Your password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm your password please")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Repassword are different")]
        public string RePassword { get; set; }

    }
}
