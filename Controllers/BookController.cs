using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;


namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository= null;
        private readonly ILanguageRepository _LanguageRepository = null; 
        private readonly IWebHostEnvironment _webHostEnvironment = null;

        [ViewData]
        public string Title { get; set; }
        public BookController(IBookRepository bookRepository, ILanguageRepository languageRepository, IWebHostEnvironment webHostEnvironment)
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
        [Authorize] // available only for Logined user
        public ViewResult AddNewbook(bool isSuccess = false, int bookId = 0)
        {
            //ViewBag.Language = new SelectList (await _LanguageRepository.GetLanguages(), "Id", "Name");
            Title = "Add New Book";
            ViewBag.IsSuccess = isSuccess;
            ViewBag.bookId = bookId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewbook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                if(bookModel.CoverPhoto != null)
                {
                    string imgFolder = "book/cover/";
                    bookModel.CoverImgeUrl = await UpladImage(imgFolder, bookModel.CoverPhoto);
                }
                if(bookModel.GalleryFiles != null)
                {
                    string imgFolder = "book/gallery/";
                    bookModel.GalleryUrl = new List<GalleryModel>();

                    foreach (var file in bookModel.GalleryFiles)
                    {
                        var gallery = new GalleryModel()
                        {
                            Name = file.FileName,
                            URL = await UpladImage(imgFolder, file)
                        };
                        bookModel.GalleryUrl.Add(gallery);
                    }

                }
                if (bookModel.BookPdf != null)
                {
                    string imgFolder = "book/bookPdf/";
                    bookModel.PDFUrl = await UpladImage(imgFolder, bookModel.BookPdf);
                }
                int id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewbook), new { isSuccess = true, bookId = id });
                }
               
            }

            //ViewBag.Language = new SelectList(await _LanguageRepository.GetLanguages(), "Id", "Name");
            return View();

        }
        private async Task<string> UpladImage(string imgFolder, IFormFile file)
        {
            imgFolder += Guid.NewGuid().ToString() + "-" + file.FileName;
            string serverImgFolder = Path.Combine(_webHostEnvironment.WebRootPath, imgFolder);
            await file.CopyToAsync(new FileStream(serverImgFolder, FileMode.Create));
            return  "/" + imgFolder;
        }
       
    }
}
