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
    public class GenresRepository
    {
        private BookStoreDbContext context = null;

        public GenresRepository()
        {
            context = new BookStoreDbContext();
        }



        public List<Genres> GetAll()
        {
            return context.Genres.ToList();
        }


        public void Insert(Genres genres)
        {

            context.Genres.Add(genres);
            context.SaveChanges();
        }

        public Genres GetById(int id)
        {
            return context.Genres.Where(i => i.GenresId == id)
                                .FirstOrDefault();
        }
        public Genres GetFirstOrDefault(Expression<Func<Genres, bool>> filter)
        {
            return context.Genres.Where(filter)
                                .FirstOrDefault();
        }

        public void Update(Genres item)
        {
            DbEntityEntry entry = context.Entry(item);
            entry.State = EntityState.Modified;

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Genres item = GetById(id);

            if (item != null)
            {
                context.Genres.Remove(item);
                context.SaveChanges();
            }

        }
    }
}