using SignUp.DAL;
using SignUp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignUp.Controllers
{
    public class SignUpController : Controller
    {
        private SignUpDAL signUpDAL = new SignUpDAL();

        [HttpGet]
        public ActionResult SignUp()
        {
            return View(new SignUpModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(SignUpModel model)
        {
            if (ModelState.IsValid)
            {
                string profilePicturePath = null;

               
                if (model.ProfilePicture != null && model.ProfilePicture.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(model.ProfilePicture.FileName);

                   
                    string uploadDirectory = @"C:\Users\12816\Downloads\SignUp\Uploads"; 
                    if (!Directory.Exists(uploadDirectory))
                    {
                        Directory.CreateDirectory(uploadDirectory); 
                    }

                    profilePicturePath = Path.Combine(uploadDirectory, fileName);

                  
                    model.ProfilePicture.SaveAs(profilePicturePath);

                    
                    profilePicturePath = "~/Uploads/" + fileName; 

                    
                }

                
             
                bool userAdded = signUpDAL.AddUser(model.Username, model.Email, model.Password, model.ConfirmPassword, profilePicturePath);

                if (userAdded)
                {
                   
                    return RedirectToAction("AllUsers");
                }
                else
                {
                    
                    ModelState.AddModelError("", "Failed to register user. Please try again.");
                }
            }
            else
            {
                ViewBag.ShowModal = true;

            }

            
            return View(model);
        }

        public ActionResult AllUsers()
        {
            List<SignUpModel> users = new List<SignUpModel>();

            try
            {
               
                users = signUpDAL.GetAllUsers();
            }
            catch (Exception ex)
            {
               
                ModelState.AddModelError("", "Failed to retrieve users. Please try again.");
            }

            return View(users);
        }

    }
}