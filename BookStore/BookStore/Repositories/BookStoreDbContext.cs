using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookStore.Repositories
{

        public class BookStoreDbContext : DbContext
        {
            public DbSet<Books> Books { get; set; }

            public DbSet<User> Users { get; set; }
            public DbSet<BorrowedBooks> Borrowed { get; set; }
            public DbSet<Genres> Genres { get; set; }


        public BookStoreDbContext()
                : base(@"Server=localhost\SQLEXPRESS; Database= LibraryDB;
                    User Id=irina; Password=irina;")
            {
                Books = Set<Books>();
                Users = Set<User>();
                Borrowed = Set<BorrowedBooks>();
                Genres = Set<Genres>();
            

        }
        }
    }

