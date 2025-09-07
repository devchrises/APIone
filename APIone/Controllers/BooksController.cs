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
    }
}