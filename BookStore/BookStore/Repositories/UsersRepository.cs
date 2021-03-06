using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;


namespace BookStore.Repositories
{
    public class UsersRepository
    {
        private  BookStoreDbContext context = null;

        public UsersRepository()
        {
            context = new BookStoreDbContext();
        }

       

        public List<User> GetAll()
        {
            return context.Users.ToList();
        }


        public void Insert(User item)
        {
            context.Users.Add(item);
            context.SaveChanges();
        }

        public void Update(User item)
        {
            DbEntityEntry entry = context.Entry(item);
            entry.State = EntityState.Modified;

            context.SaveChanges();
        }
        public User GetById(int id)
        {
            return context.Users.Where(i => i.User_Id == id)
                                .FirstOrDefault();
        }
        public User GetFirstOrDefault(Expression<Func<User, bool>> filter)
        {
            return context.Users.Where(filter)
                                .FirstOrDefault();
        }

        public void Delete(int id)
        {
            User item = GetById(id);

            if (item != null)
            {
                context.Users.Remove(item);
                context.SaveChanges();
            }

        }

    }
}

