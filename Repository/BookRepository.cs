using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }
        public BookModel GetBookById(int id)
        {
            //FirstOrDefault if value not found it returns null
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }
        public List<BookModel> SearchBook(string title, string author)
        {
            return DataSource().Where(x => x.Title == title && x.Author == author).ToList();
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
    }
}
