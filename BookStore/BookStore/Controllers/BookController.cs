using BookStore.Entities;
using BookStore.Repositories;
using BookStore.ViewModels.Books;
using BookStore.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            if (Session["loggedUser"] == null) { 
                return RedirectToAction("Login", "Home");}



            // BookRepository BookRepo = new BookRepository();
            // ViewData["books"] = BookRepo.GetAll();

            BorrowRepository BookRepo = new BorrowRepository();
            ViewData["borrow"] = BookRepo.GetAll();
        
          
          
          
            ///---------------------------
            BookStoreDbContext db = new BookStoreDbContext();

            var DisplayBook = from g in db.Genres
                              join b in db.Books
                              on g.GenresId equals b.GenresId   
                              select new AddVM
                             {
                                  Book_Id = b.Book_Id,
                                  ISBN=b.ISBN,
                                  Title = b.Title,
                                  AuthorName = b.AuthorName,
                                  genre = g.GenresName
                             };

          

            return View(DisplayBook);
        }

        
        public ActionResult BookError()
        {
            if (Session["loggedUser"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            return View();

        }
        [HttpGet]
        public ActionResult Add()
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            return View();
        }

        [HttpPost]
        public ActionResult Add(AddVM model)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            if (!ModelState.IsValid)
                return View(model);

            BookStoreDbContext BooksContext = new BookStoreDbContext();
            Books book = new Books();
            
            if (BooksContext.Books.Any(o => o.ISBN == model.ISBN )  ||
                BooksContext.Books.Any(o => o.Book_Id == model.Book_Id))
            {

                return RedirectToAction("BookError", "Book");
            }
            else
            {
                book.Book_Id = model.Book_Id;
                book.ISBN = model.ISBN;
                book.Title = model.Title;
                book.AuthorName = model.AuthorName;
                book.GenresId = model.GenresId;
              
                BookRepository repo = new BookRepository();

                repo.Insert(book);
            }
            

            return RedirectToAction("Index", "Book");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            if (Session["loggedUser"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            BookRepository repo = new BookRepository();
            Books item = repo.GetById(Id);

            EditVM model = new EditVM();
            model.Book_Id = item.Book_Id;
            model.ISBN = item.ISBN;
            model.Title = item.Title;
            model.AuthorName = item.AuthorName;
            model.genre = item.genre.GenresName;
            model.GenresId = item.GenresId;
           
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(EditVM model)
        {
            if (Session["loggedUser"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            Books item = new Books();
            item.Book_Id = model.Book_Id;
            item.ISBN = model.ISBN;
            item.Title = model.Title;
            item.AuthorName = model.AuthorName;
            item.GenresId = model.GenresId;

            BookRepository repo = new BookRepository();
            repo.Update(item);

            return RedirectToAction("Index", "Book");
        }

        public ActionResult Delete(int id)
        {
            if (Session["loggedUser"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            BookRepository repo = new BookRepository();
            repo.Delete(id);

            return RedirectToAction("Index", "Book");
        }
    }


}
