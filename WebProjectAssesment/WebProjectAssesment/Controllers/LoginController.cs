using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using static System.Collections.Specialized.BitVector32;
using System.Web.Optimization;
using System.Web.UI.WebControls;
using WebProjectAssesment;
using WebProjectAssesment.Models;
using System.Web.Security;

namespace WebProjectAssesment.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
       
        /// Conecting database to the contriller       
        webDatabaseEntities db=new webDatabaseEntities();

        // GET: Login
        public ActionResult Login()
        {
            
            return View();
        }

        /// <summary>
        /// this function check username and Password are Matched or not
        /// </summary>
        /// <returns>set username as cookie</returns>
        [HttpPost]
        public ActionResult Login(LoginModel log)
        {
            try
            {
                //checking Username and Password is correct
              var User=db.tblUsers.Where(w => w.Email.ToLower() == log.Username.ToLower() && w.Password == log.password).FirstOrDefault();                 
                
              if (User != null)
                {
                    //set cookie for user
                    FormsAuthentication.SetAuthCookie(log.Username, false);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.msg = "Invalid Credentials.";
                }
              return View();

            }
            catch (Exception er)
            {
                return View(er.Message);
                
            }

        }

        //logout the user 
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("index","Home");
        }
    }
}


