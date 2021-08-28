using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            //dynamic data = new ExpandoObject();
            //data.id = 3;
            //data.Name = "rekha";
            //ViewBag.data = data;
            return View();
            
        }
        public ViewResult Aboutus()
        {
            ViewData["Property1"] = "Nitish";
            ViewData["Book"] = new BookModel() { Id = 1, Author = "Rekha" };
            return View();
        }
        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
