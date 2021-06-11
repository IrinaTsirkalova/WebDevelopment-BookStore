using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.ViewModels.Genres
{
    public class GenreVM
    {
        public int GenreId { get; set; }
        public string GerenreName { get; set; }

        public string title { get; set; }

        public string BookAuthor { get; set; }

        public int BookId { get; set; }
    }
}