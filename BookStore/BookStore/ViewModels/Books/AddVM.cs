using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.ViewModels.Books
{
    public class AddVM
    {
            public string genre { get; set; }
       
            [DisplayName("Enter Book Id : ")]
            [Required(ErrorMessage = "This field is Required!")]
            public int Book_Id { get; set; }

            [DisplayName("Enter Book ISBN : ")]
            [Required(ErrorMessage = "This field is Required!")]
            public int ISBN { get; set; }

            [DisplayName("Enter book title: ")]
            [Required(ErrorMessage = "This field is Required!")]
            public string Title { get; set; }

            [DisplayName("Enter author's full name: ")]
            [Required(ErrorMessage = "This field is Required!")]
            public string AuthorName { get; set; }

           [DisplayName("Enter  Genres Id: ")]
           [Required(ErrorMessage = "This field is Required!")]
           public int GenresId { get; set; }

           
       
    
}
}