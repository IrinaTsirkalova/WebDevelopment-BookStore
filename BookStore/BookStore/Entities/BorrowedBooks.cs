using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookStore.Entities
{
    public class BorrowedBooks
    {
        [Key]
        public int Borrow_Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public int numBook { get; set; }

        public DateTime BorrowDate { get; set; }

        public DateTime ReturnDate { get; set; }

        [ForeignKey("BookId")]
        public virtual Books Book { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

       
    }
}