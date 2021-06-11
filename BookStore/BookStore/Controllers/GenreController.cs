using BookStore.Repositories;
using BookStore.ViewModels.Genres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class GenreController : Controller
    {
        
        public ActionResult Index()
        {
            if (Session["loggedUser"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
        
            return View();

        }

        public ActionResult GenreBook(int id)
        {
            if (Session["loggedUser"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

           
            
            BookStoreDbContext db = new BookStoreDbContext();
            var DisplayBookGenre = from g in db.Genres
                                   join b in db.Books
                                   on g.GenresId equals b.GenresId
                                   where g.GenresId == id
                                   select new GenreVM
                                 {
                                   BookId= b.Book_Id,
                                   title = b.Title,
                                   BookAuthor = b.AuthorName
                                   
                                 };
            
            return View(DisplayBookGenre);

          
        }
    }
}