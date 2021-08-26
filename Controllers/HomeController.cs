using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            // accessing views from different location and view name is different than the action method 
            // using two types of access 
            //1.FullPath  (file extension is mandatory)
           // return View("TempView/Index.cshtml"); OR return View("~/TempView/Index.cshtml");

            //2. relative Path

            return View("../../TempView/Index");
            
        }
        public ViewResult Aboutus()
        {
            return View();
        }
        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
