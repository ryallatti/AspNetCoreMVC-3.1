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
        [ViewData]
        public string CustomProperty { get; set; }
        
        [ViewData]
        public string Title { get; set; }

        [ViewData]
        public BookModel book { get; set; }
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
            //viewdata attribute 
            CustomProperty = "Custom Value";

            Title = "Home Page";

            book = new BookModel() { Id = 3, Title = "Asp.Net core tutorial" };
            //viewdata
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
