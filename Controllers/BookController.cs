using BookStore;
using BookStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {

        [HttpPost]
        public ActionResult<string> AddBooks( [FromBodyAttribute] List<Book> bookList )
        {
            foreach (Book book in bookList) {

                var exisitingBook = Program.BookStorage.FirstOrDefault(x => x.Title == book.Title);

                if (exisitingBook != null)
                {
                    exisitingBook.stock += book.stock;
                }
                else {
                    Program.BookStorage.Add(book);
                }

            }

            OkResult ok = new OkResult();
            return ok;
        }


        [HttpGet]
        public List<Book> ListBooks() {
            
            
            return Program.BookStorage;
        }
    }
}
