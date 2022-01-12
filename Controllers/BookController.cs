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
        /// <summary>
        /// Adds a list of books
        /// </summary>
        /// <param name="bookList"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<string> AddBooks( [FromBodyAttribute] List<Book> bookList )
        {
            foreach (Book book in bookList) {

                var existingBook = Program.BookStorage.FirstOrDefault(x => x.Title == book.Title);

                if (existingBook != null)
                {
                    existingBook.stock += book.stock;
                }
                else {
                    Program.BookStorage.Add(book);
                }

            }

            return new OkResult();
        }
        /// <summary>
        /// Updates the stock of a book list
        /// </summary>
        /// <param name="bookList"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<string> UpdateBooks([FromBodyAttribute] List<Book> bookList)
        {
            foreach (Book book in bookList)
            {

                var existingBook = Program.BookStorage.FirstOrDefault(x => x.Title == book.Title);

                if (existingBook != null)
                {
                    existingBook.stock = book.stock;
                }
                else
                {
                    Program.BookStorage.Add(book);
                }

            }

            return new OkResult();
        }
        /// <summary>
        /// Removes a list of books
        /// </summary>
        /// <param name="bookList"></param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult<string> RemoveBooks([FromBodyAttribute] List<Book> bookList)
        {
            foreach (Book book in bookList)
            {

                var existingBook = Program.BookStorage.FirstOrDefault(x => x.Title == book.Title);

                if (existingBook != null)
                {
                    Program.BookStorage.Remove(existingBook);
                }
            }

            return new OkResult();
        }
        /// <summary>
        /// Remove one book by title
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        [HttpDelete("title")]
        public ActionResult<string> RemoveBookByTitle(string title)
        {
            
            var existingBook = Program.BookStorage.FirstOrDefault(x => x.Title == title);

            if (existingBook != null)
            {
                Program.BookStorage.Remove(existingBook);
            }

            return new OkResult();
        }
        /// <summary>
        /// Returns one existing book by title
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        [HttpGet("title")]
        public Book GetOneBook(string title )
        {
            var existingBook = Program.BookStorage.FirstOrDefault(x => x.Title == title);

            return existingBook;
        }

        /// <summary>
        /// Returns all the existing books
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Book> ListBooks() {
            
            
            return Program.BookStorage;
        }
    }
}
