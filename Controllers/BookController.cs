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
        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
       
        public async Task<ViewResult> GetAllBooks()
        {
            var data = await _bookRepository.GetAllBooks();
            return View(data);
        }
        [Route("boook-details/id", Name = "bookDetailsRoute")]
        public async Task<ViewResult> GetBookDetails(int id)
        {
            var details = await _bookRepository.GetBookById(id);
            return View(details) ;
        }
        public async Task<List<BookModel>> SearchBooks(string title, string Author)
        {

            return await _bookRepository.SearchBook(title, Author);
        }
        public ViewResult AddNewbook(bool isSuccess = false, int bookId = 0)
        {
            Title = "Add New Book";
            ViewBag.IsSuccess = isSuccess;
            ViewBag.bookId = bookId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewbook(BookModel book)
        {
            int id = await _bookRepository.AddNewBook(book);
            if(id > 0)
            {
                return RedirectToAction(nameof(AddNewbook), new { isSuccess = true , bookId = id});
            }
            return View();
        }
    }
}
