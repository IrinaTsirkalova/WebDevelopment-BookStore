using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace BookStore.ViewModels.Borrow
{
    public class IndexVM
    {
        public int Book_Id { get; set; }
        public int ISBN { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }

        public int Borrow_Id { get; set; }
        [DisplayName("Enter the number of books you want to borrow:" )]
        public int numBook { get; set; }

        [DisplayName("Enter borrow date:")]
        public DateTime BorrowDate { get; set; }
        [DisplayName("Enter return date:")]
        public DateTime ReturnDate { get; set; }

        public int User_Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<User> user { get; set; }
        public List<Entities.Books> book { get; set; }

        public List<BorrowedBooks> borrow { get; set; }
        public List<Entities.Genres> genre { get; set; }
        public string GenreName { get; set; }


    }
}