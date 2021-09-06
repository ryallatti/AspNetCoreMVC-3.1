using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using BookStore.Models;
using Microsoft.Extensions.Configuration;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [ViewData]
        public string CustomProperty { get; set; }
        
        [ViewData]
        public string Title { get; set; }

        [ViewData]
        public BookModel book { get; set; }
        public ViewResult Index()
        {
            var appName = _configuration["AppName"];
            var Key1 = _configuration["InfoObj:Key1"];
            var Key2 = _configuration["InfoObj:Key2"];
            var Key3 = _configuration["InfoObj:Key3:Key3Obj"];
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
