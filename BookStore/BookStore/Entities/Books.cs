using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Entities
{
    public class Books
    {

        [Key]
        public int Book_Id { get; set; }
        public int GenresId { get; set; }
        public int ISBN { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }

        [ForeignKey("GenresId")]
        public virtual Genres genre { get; set; }
       
      
    }
}