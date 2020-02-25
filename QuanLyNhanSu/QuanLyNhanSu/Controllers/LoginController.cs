using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Windows;

namespace QuanLyNhanSu.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {

            
            return View();
        }
        [HttpPost]
        public ActionResult Login()
        {
            string user = Request.Form["Usernametext"];
            string pass = Request.Form["Passwordtext"];
            if (user == "admin" && pass == "admin" )
            {
                return RedirectToAction("Index", "Home", null);
            }
            else
            {
                MessageBox.Show("Wrong id and password");

                return RedirectToAction("Index", "Login", null);
            }
        }
    }
}