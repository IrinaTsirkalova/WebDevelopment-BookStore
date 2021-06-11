using BookStore.Entities;
using BookStore.Repositories;
using BookStore.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            UsersRepository repo = new UsersRepository();
            ViewData["items"] = repo.GetAll();

            return View();
        }

        public ActionResult UserError()
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            return View();
        }

        public ActionResult Users()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Registration()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Registration(RegistrationVM model)
        {

          
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            User user = new User();
            BookStoreDbContext contextUser = new BookStoreDbContext();

            if (contextUser.Users.Any(o => o.Username == model.Username) ||
                contextUser.Users.Any(o => o.Password == model.Password))
            {

                return RedirectToAction("UserError", "Users");
            }
            else
            {
                user.Username = model.Username;
                user.Password = model.Password;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;

                UsersRepository repo = new UsersRepository();
                repo.Insert(user);
            }
            return RedirectToAction("Index", "Users");
        }


        [HttpGet]
        public ActionResult Edit(int Id)
        {
            if (Session["loggedUser"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            UsersRepository repo = new UsersRepository();
            User item = repo.GetById(Id);

            EditVM model = new EditVM();
            model.User_Id = item.User_Id;
            model.Username = item.Username;
            model.Password = item.Password;
            model.FirstName = item.FirstName;
            model.LastName = item.LastName;

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


            User item = new User();
            item.User_Id = model.User_Id;
            item.Username = model.Username;
            item.Password = model.Password;
            item.FirstName = model.FirstName;
            item.LastName = model.LastName;

            UsersRepository repo = new UsersRepository();
            repo.Update(item);

            return RedirectToAction("Index", "Users");
        }

        public ActionResult Delete(int id)
        {
            if (Session["loggedUser"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            UsersRepository repo = new UsersRepository();
            repo.Delete(id);

            return RedirectToAction("Index", "Users");
        }
    }



}