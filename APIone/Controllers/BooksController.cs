using APIone.Data;
using APIone.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        //static private List<Book> books = new List<Book>
        //{
        //    new Book
        //    {
        //        Id = 1,
        //        Author = "A1",
        //        Title = "T1",
        //        YearPublished = 2001
        //    },
        //    new Book
        //    {
        //        Id = 2,
        //        Author = "A2",
        //        Title = "T2",
        //        YearPublished = 2002
        //    },
        //    new Book
        //    {
        //        Id = 3,
        //        Author = "A3",
        //        Title = "T3",
        //        YearPublished = 2003
        //    },
        //    new Book
        //    {
        //        Id = 4,
        //        Author = "A4",
        //        Title = "T4",
        //        YearPublished = 2004
        //    },
        //    new Book
        //    {
        //        Id = 5,
        //        Author = "A5",
        //        Title = "T5",
        //        YearPublished = 2005
        //    }
        //};

        private readonly FirstAPIContext _context;
        public BooksController(FirstAPIContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            return Ok(await _context.Books.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public async Task<ActionResult<Book>> AddBook(Book newBook)
        {
            if (newBook == null)
            {
                return BadRequest();
            }

            _context.Books.Add(newBook);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBookById), new { id = newBook.Id }, newBook);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, Book updateBook)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return NotFound();

            book.Author = updateBook.Author;
            book.Title= updateBook.Title;
            book.YearPublished = updateBook.YearPublished;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return NotFound();

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}