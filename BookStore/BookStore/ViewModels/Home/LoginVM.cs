using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.ViewModels.Home
{

     public class LoginVM
        {
            [DisplayName("Username: ")]
            [Required(ErrorMessage = "This field is Required! Please enter your username!")]
            public string Username { get; set; }

            [DisplayName("Password: ")]
            [Required(ErrorMessage = "This field is Required! Please enter your password!")]
            public string Password { get; set; }
        }
    }
