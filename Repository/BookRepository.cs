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
            var books = new List<BookModel>();
            var AllBooks = await _context.Books.ToListAsync();
            if(AllBooks?.Any() == true)
            {
              foreach(var book in AllBooks)
                {
                    books.Add(new BookModel()
                    {
                        Author = book.Author,
                        Title = book.Title,
                        Category = book.Category,
                        Id = book.Id,
                        Language = book.Language,
                        TotalPages = book.TotalPages,
                        Description = book.Description
                    });
                }
            }
            return books;
        }
        public async Task<BookModel> GetBookById(int id)
        {
            //FirstOrDefault if value not found it returns null
            var book = await _context.Books.FindAsync(id);
            //OR
            //var book1 =  _context.Books.Where(x => x.Id == id).FirstOrDefault();
           if(book != null)
            {
                var bookDetails = new BookModel()
                {
                    Author = book.Author,
                    Title = book.Title,
                    Category = book.Category,
                    Id = book.Id,
                    Language = book.Language,
                    TotalPages = book.TotalPages,
                    Description = book.Description
                };
                return bookDetails;
            }
            return null;
        }
        public async Task<List<BookModel>> SearchBook(string title, string author)
        {
            // return DataSource().Where(x => x.Title == title && x.Author == author).ToList();
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
                        Language = book.Language,
                        TotalPages = book.TotalPages,
                        Description = book.Description
                    });
                }
            }
            return books;
        }
        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id = 1, Title="Asp.Net Core MVC",Author="Joy",Description="This is Core Book",Category="Programming",TotalPages=200, Language="English"},
                new BookModel(){Id = 2, Title="MVC",Author="Roy",Description="This is MVC Book",Category="Programming",TotalPages=398, Language="English"},
                new BookModel(){Id = 3, Title="C#",Author="John", Description="This is C# Book",Category="Developer",TotalPages=547, Language="English"},
                new BookModel(){Id = 4, Title="Java",Author="Aryan", Description="This is Java Book",Category="Concept",TotalPages=100, Language="English"},
                new BookModel(){Id = 5, Title="Angular",Author="atharva",Description="This is Angular Book",Category="Programming",TotalPages=190, Language="English"},
                new BookModel(){Id = 6, Title="Azure",Author="Yuva",Description="This is Azure Book",Category="Programming",TotalPages=123, Language="English"}

            };


        }
        public async Task<int> AddNewBook(BookModel model)
        {
            //assigning model to entity class (nothing but table)
            var newBook = new Books()
            {
                Author = model.Author,
                Title = model.Title,
                CreatedOn = model.CreatedOn,
                TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0,
                UpdatedOn = DateTime.UtcNow
            };
           await _context.Books.AddAsync(newBook);
           await _context.SaveChangesAsync();
            return newBook.Id;
        }
    }
}
