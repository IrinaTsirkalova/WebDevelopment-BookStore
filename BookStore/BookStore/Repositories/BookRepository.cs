using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BookStore.Repositories
{
    public class BookRepository
    {
        private BookStoreDbContext context = null;

        public BookRepository()
        {
            context = new BookStoreDbContext();
        }



        public List<Books> GetAll()
        {
            return context.Books.ToList();
        }


        public void Insert(Books books)
        {
            
            context.Books.Add(books);
            context.SaveChanges();
        }

        public Books GetById(int id)
        {
            return context.Books.Where(i => i.Book_Id == id)
                                .FirstOrDefault();
        }
        public Books GetFirstOrDefault(Expression<Func<Books, bool>> filter)
        {
            return context.Books.Where(filter)
                                .FirstOrDefault();
        }

        public void Update(Books item)
        {
            DbEntityEntry entry = context.Entry(item);
            entry.State = EntityState.Modified;

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Books item = GetById(id);

            if (item != null)
            {
                context.Books.Remove(item);
                context.SaveChanges();
            }

        }

    }



   
    
}
