using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyNhanSu.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

       

        public ActionResult Guide()
        {
            ViewBag.Message = "Your guide page.";

            return View();
        }


    }
}