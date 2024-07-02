using SignUp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignUp.Controllers
{
    public class SignUpController : Controller
    {
        private SignUpContext db = new SignUpContext();

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
                    model.ProfilePicturePath = "~/Uploads/" + fileName;
                }

                db.Users.Add(model);
                db.SaveChanges();
                return RedirectToAction("AllUsers");
            }
            else
            {
                ViewBag.ShowModal = true;
            }

            return View(model);
        }

        public ActionResult AllUsers()
        {
            List<SignUpModel> users = db.Users.ToList();
            return View(users);
        }
    }
}
