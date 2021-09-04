using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class BookRepository
    {
        public readonly BookStoreContext _context = null;
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
           return await _context.Books.Select(book => new BookModel()
            {
                Author = book.Author,
                Title = book.Title,
                Category = book.Category,
                Id = book.Id,
                LanguageId = book.LanguageId,
                LanguageName = book.Language.Name,
                TotalPages = book.TotalPages,
                Description = book.Description,
               CoverImgeUrl = (book.CoverImgeUrl.StartsWith("/") == true) ? book.CoverImgeUrl : "/" + book.CoverImgeUrl
           }).ToListAsync();
        }
        public async Task<BookModel> GetBookById(int id)
        {
            return await _context.Books.Where(x => x.Id == id).Select(book => new BookModel()
            {
                Author = book.Author,
                Title = book.Title,
                Category = book.Category,
                Id = book.Id,
                LanguageId = book.LanguageId,
                LanguageName = book.Language.Name,
                TotalPages = book.TotalPages,
                Description = book.Description,
                CoverImgeUrl = (book.CoverImgeUrl.StartsWith("/") == true) ? book.CoverImgeUrl : "/" + book.CoverImgeUrl,
                GalleryUrl = book.BookGallery.Select(gallery => new GalleryModel()
                {
                   Id=gallery.Id,
                   Name = gallery.Name,
                   URL = gallery.URL
                }).ToList()
            }).FirstOrDefaultAsync();
        }
        public async Task<List<BookModel>> SearchBook(string title, string author)
        {
            var books = new List<BookModel>();
            var AllBooks = await _context.Books.Where(x=>x.Title == title && x.Author == author).ToListAsync();
            if (AllBooks?.Any() == true)
            {
                foreach (var book in AllBooks)
                {
                    books.Add(new BookModel()
                    {
                        Author = book.Author,
                        Title = book.Title,
                        Category = book.Category,
                        Id = book.Id,
                        LanguageId = book.LanguageId,
                        LanguageName = book.Language.Name,
                        TotalPages = book.TotalPages,
                        Description = book.Description,
                        CoverImgeUrl = book.CoverImgeUrl
                    });
                }
            }
            return books;
        }
      
        public async Task<int> AddNewBook(BookModel model)
        {
            //assigning model to entity class (nothing but table)
            var newBook = new Books()
            {
                Author = model.Author,
                Title = model.Title,
                LanguageId = model.LanguageId,
                CreatedOn = model.CreatedOn,
                TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0,
                UpdatedOn = DateTime.UtcNow,
                Category = model.Category,
                CoverImgeUrl = model.CoverImgeUrl
            };
            newBook.BookGallery = new List<Gallery>();
            foreach (var file in model.GalleryUrl)
            {
                newBook.BookGallery.Add(new Gallery()
                {
                    Name = file.Name,
                    URL = file.URL
                });
            }
           await _context.Books.AddAsync(newBook);
           await _context.SaveChangesAsync();
            return newBook.Id;
        }
    }
}
