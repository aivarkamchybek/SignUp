
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Entities;
using Service.Interfaces;
using Service;


namespace SignUp.Controllers
{
    public class SignUpController : Controller
    {
        private readonly IUserService _userService;

        public SignUpController()
        {
            _userService = new UserService();

        }

        [HttpGet]
        public ActionResult SignUp()
            
        {
            var user = new User();
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(User model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _userService.SignUp(model.Username, model.Email, model.Password, model.ConfirmPassword);
                    return RedirectToAction("AllUsers");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }

            ViewBag.ShowModal = true;
            return View(model);
        }

        public ActionResult AllUsers()
        {
            var users = _userService.GetAllUsers();

            return View(users);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _userService.EditUser(model);
                    return RedirectToAction("AllUsers");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

    
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _userService.DeleteUser(id);
                return RedirectToAction("AllUsers");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("Error");
            }
        }
    }
}