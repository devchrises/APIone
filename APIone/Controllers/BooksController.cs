using APIone.models;
using Microsoft.AspNetCore.Mvc;

namespace APIone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        static private List<Book> books = new List<Book>
        {
            new Book
            {
                Id = 1,
                Author = "A1",
                Title = "T1",
                YearPublished = 2001
            },
            new Book
            {
                Id = 2,
                Author = "A2",
                Title = "T2",
                YearPublished = 2002
            },
            new Book
            {
                Id = 3,
                Author = "A3",
                Title = "T3",
                YearPublished = 2003
            },
            new Book
            {
                Id = 4,
                Author = "A4",
                Title = "T4",
                YearPublished = 2004
            },
            new Book
            {
                Id = 5,
                Author = "A5",
                Title = "T5",
                YearPublished = 2005
            }
        };

        [HttpGet]
        public ActionResult<List<Book>> GetBooks()
        {
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(int id)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public ActionResult<Book> AddBook(Book newBook)
        {
            if (newBook == null)
            {
                return BadRequest();
            }

            books.Add(newBook);
            return CreatedAtAction(nameof(GetBookById), new { id = newBook.Id }, newBook);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Book updateBook)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            if (book == null) return NotFound();

            book.Id = updateBook.Id;
            book.Author = updateBook.Author;
            book.Title = updateBook.Title;
            book.YearPublished = updateBook.YearPublished;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            if (book == null) return NotFound();
            
            books.Remove(book);
            return NoContent();
        }
    }
}