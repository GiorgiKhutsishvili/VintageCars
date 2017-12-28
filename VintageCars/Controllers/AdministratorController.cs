using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VintageCars.Models;

namespace VintageCars.Controllers
{
    public class AdministratorController : Controller
    {
        // GET: Administrator
        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(Login login)
        {
            return View();
        }


        public ActionResult Adminpanel()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Adminpanel()
        //{
        //    return View();
        //}

    }
}