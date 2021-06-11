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
    public class BorrowRepository
       
    {
        private BookStoreDbContext context = null;
        protected DbSet<BorrowedBooks> Items { get; set; }
        public BorrowRepository()
        {
            context = new BookStoreDbContext();
        }



        public List<BorrowedBooks> GetAll()
        {
           

            return context.Borrowed.ToList();


        }


        public void Insert(BorrowedBooks borrow)
        {
            context.Borrowed.Add(borrow);
            context.SaveChanges();
        }

        public void Update(BorrowedBooks borrow)
        {
            DbEntityEntry entry = context.Entry(borrow);
            entry.State = EntityState.Modified;

            context.SaveChanges();
        }
        public BorrowedBooks GetById(int id)
        {
            return context.Borrowed.Where(i => i.Borrow_Id == id)
                                .FirstOrDefault();
        }
        public BorrowedBooks GetFirstOrDefault(Expression<Func<BorrowedBooks, bool>> filter)
        {
            return context.Borrowed.Where(filter)
                                .FirstOrDefault();
        }

     

    }
}