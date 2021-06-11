using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.ViewModels.Users
{
    public class RegistrationVM
    {
       
            [DisplayName("Enter username: ")]
            [Required(ErrorMessage = "Username is required!")]
            public string Username { get; set; }

            [DisplayName(" Enter password: ")]
            [Required(ErrorMessage = "Password is required!")]
            public string Password { get; set; }

            [DisplayName("Enter first name: ")]
            [Required(ErrorMessage = "First name is required!")]
            public string FirstName { get; set; }

            [DisplayName("Enter last name: ")]
            [Required(ErrorMessage = "Last name is required!")]
            public string LastName { get; set; }
      
    }
}