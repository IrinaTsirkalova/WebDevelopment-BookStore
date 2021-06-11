using BookStore.Entities;
using BookStore.Repositories;
using BookStore.ViewModels.Borrow;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class BorrowController : Controller
    {

        // GET: Borrow
        public ActionResult Index()
        {

            if (Session["loggedUser"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            BorrowRepository BookRepo = new BorrowRepository();
            ViewData["borrow"] = BookRepo.GetAll();

            UsersRepository userRepo = new UsersRepository();
            User Current = (User)Session["loggedUser"];
            int userID = Current.User_Id;
            User user = userRepo.GetById(userID);

           
            ///---------------------------
            BookStoreDbContext db = new BookStoreDbContext();

            var borrowBook = from bb in db.Borrowed
                              join b in db.Books
                              on bb.BookId equals b.Book_Id
                              join u in db.Users
                              on bb.UserId equals u.User_Id
                              join g in db.Genres
                              on b.GenresId equals g.GenresId
                              where bb.UserId== userID
                              select new IndexVM
                              {
                                  Title = b.Title,
                                  Username = u.Username,
                                  numBook = bb.numBook,
                                  ReturnDate = bb.ReturnDate,
                                  BorrowDate = bb.BorrowDate,
                                  GenreName = g.GenresName
                                  
                              };


            //var r = borrowBook.Where(i => i.User_Id == userID); To-Do
         
            return View(borrowBook);
        }
      
       
        [HttpGet]
        public ActionResult Borrow(int Id)
        {
            if (Session["loggedUser"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

          
            IndexVM model = new IndexVM();
            UsersRepository userRepo = new UsersRepository();
            BookRepository bookRepo = new BookRepository();
            
            Books book = bookRepo.GetById(Id);

            User Current = (User)Session["loggedUser"];
            int userID = Current.User_Id;
            User user = userRepo.GetById(userID);

            model.Username = user.Username;
            model.User_Id = user.User_Id;
            model.Book_Id = book.Book_Id;
            model.ISBN = book.ISBN;
            model.Title = book.Title;
            model.AuthorName = book.AuthorName;
            
           



            return View(model);
        }
     
        [HttpPost]
        public ActionResult Borrow(IndexVM model)
        {
            if (Session["loggedUser"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }

           BorrowedBooks item = new BorrowedBooks();
          
            item.BookId = model.Book_Id;
            item.UserId = model.User_Id;
            item.numBook = model.numBook;
            item.BorrowDate = model.BorrowDate;
            item.ReturnDate = model.ReturnDate;


            BorrowRepository repoBorrow = new BorrowRepository();
            repoBorrow.Insert(item);

            return RedirectToAction("Index", "Borrow");


        }





    }
}