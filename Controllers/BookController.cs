using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository= null;
        private readonly LanguageRepository _LanguageRepository = null; 
        private readonly IWebHostEnvironment _webHostEnvironment = null;

        [ViewData]
        public string Title { get; set; }
        public BookController(BookRepository bookRepository,LanguageRepository languageRepository, IWebHostEnvironment webHostEnvironment)
        {
            _bookRepository = bookRepository;
            _LanguageRepository = languageRepository;
            _webHostEnvironment = webHostEnvironment;
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
        public async Task<ViewResult> AddNewbook(bool isSuccess = false, int bookId = 0)
        {
            ViewBag.Language = new SelectList (await _LanguageRepository.GetLanguages(), "Id", "Name");
            Title = "Add New Book";
            ViewBag.IsSuccess = isSuccess;
            ViewBag.bookId = bookId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewbook(BookModel book)
        {
            if (ModelState.IsValid)
            {
                if(book.CoverPhoto != null)
                {
                    string imgFolder = "book/CoverImages/";
                    imgFolder += Guid.NewGuid().ToString() + "-" + book.CoverPhoto.FileName;
                    string serverImgFolder = Path.Combine(_webHostEnvironment.WebRootPath, imgFolder);
                    await book.CoverPhoto.CopyToAsync(new FileStream(serverImgFolder, FileMode.Create));
                    book.CoverImgeUrl = "/"+ imgFolder;
                }
                int id = await _bookRepository.AddNewBook(book);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewbook), new { isSuccess = true, bookId = id });
                }
               
            }

            ViewBag.Language = new SelectList(await _LanguageRepository.GetLanguages(), "Id", "Name");
            return View();

        }
       
    }
}
