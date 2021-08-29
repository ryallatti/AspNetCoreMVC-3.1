using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository= null;

        [ViewData]
        public string Title { get; set; }
        public BookController()
        {
            _bookRepository = new BookRepository();
        }
        public IActionResult Index()
        {
            return View();
        }
       
        public ViewResult GetAllBooks()
        {
            var data = _bookRepository.GetAllBooks();
            return View(data);
        }
        [Route("boook-details/id", Name = "bookDetailsRoute")]
        public ViewResult GetBookDetails(int id)
        {
            var details = _bookRepository.GetBookById(id);
            return View(details) ;
        }
        public List<BookModel> SearchBooks(string title, string Author)
        {

            return _bookRepository.SearchBook(title, Author);
        }
        public ViewResult AddNewbook()
        {
            Title = "Add New Book";
            return View();
        }
        [HttpPost]
        public ViewResult AddNewbook(BookModel book)
        {
           
            return View();
        }
    }
}
