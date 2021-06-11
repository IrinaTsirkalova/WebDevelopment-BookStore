using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.ViewModels.Books
{
    public class EditVM
    {
        public int Book_Id { get; set; }

        [DisplayName("Enter ISBN: ")]
        [Required(ErrorMessage = "ISBN is required!")]
        public int ISBN { get; set; }

        [DisplayName("Enter book title: ")]
        [Required(ErrorMessage = "Title is required!")]
        public string Title { get; set; }

        [DisplayName("Enter name of the author: ")]
        [Required(ErrorMessage = "Author name is required!")]
        public string AuthorName { get; set; }

        [DisplayName("Current book's genre : ")]
        [Required(ErrorMessage = "This field is Required!")]
        public string genre { get; set; }
        public int GenresId { get; set; }

    }


}