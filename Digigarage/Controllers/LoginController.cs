using Digigarage.Business.Interface;
using Digigarage.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Digigarage.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginManager _adminLoginManager;

        public LoginController(ILoginManager adminLoginManager)
        {
            _adminLoginManager = adminLoginManager;
        }
        // GET: AdminLogin
        public ActionResult Login()
        {
            return View();
        }
        //POST: Login/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel objUser)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string valid = _adminLoginManager.validAdmin(objUser);
                    if(valid!= null)
                    {
                        string role = _adminLoginManager.getRole(objUser);
                        FormsAuthentication.SetAuthCookie(valid, false);
                        if (role == "Admin")
                        {
                            return this.RedirectToAction("Index", "Admin");
                        }
                        else if (role == "Washing")
                        {
                            return this.RedirectToAction("Index", "Washing");
                        }
                        else if (role == "Repairing")
                        {
                            return this.RedirectToAction("Index", "Repairing");
                        }
                        else if (role == "Maintainance")
                        {
                            return this.RedirectToAction("Index", "Maintainance");
                        }

                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid Email Id or Password");
                        return View("Login");
                    }
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Model Error");
            }
            //Return view with user object
            return View(objUser);
        }
        //GET: Login/Logout
        //For user logout
        public ActionResult Logout()
        {
            //Logout Logic
            FormsAuthentication.SignOut();
            //ViewBag.Message("Login Successfully");
            //Return to the Login Page
            return RedirectToAction("Login", "Login");
        }
    }
}