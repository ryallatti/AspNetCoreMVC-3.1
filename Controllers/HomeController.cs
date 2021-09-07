using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using BookStore.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using BookStore.Repository;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly NewBookAlertConfig _newBookAlertConfig;
        private readonly NewBookAlertConfig _thirdPartyBookalert;
        private readonly IMessageRepository _messageRepository;

        public HomeController(IOptionsSnapshot<NewBookAlertConfig> newBookAlertConfig, IMessageRepository messageRepository)
        {
            _newBookAlertConfig = newBookAlertConfig.Get("InternalBook");
            _thirdPartyBookalert = newBookAlertConfig.Get("ThirdParty");
            _messageRepository = messageRepository;
        }
        [ViewData]
        public string CustomProperty { get; set; }
        
        [ViewData]
        public string Title { get; set; }

        [ViewData]
        public BookModel book { get; set; }
        public ViewResult Index()
        {
           
            //var newBookalert = new NewBookAlertConfig();
          
            bool isDisplay = _newBookAlertConfig.DisplayNewBookAlert;
            //var bookName = _newBookAlertConfig.BookName;
            var bookName = _messageRepository.GetName();
            var ThirdParty = _thirdPartyBookalert.BookName;
            var internalBook = _newBookAlertConfig.BookName;
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
