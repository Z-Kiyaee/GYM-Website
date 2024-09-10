using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UserLoginDTO
    {
        [Required(ErrorMessage = "Your phone number is required")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Your password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
