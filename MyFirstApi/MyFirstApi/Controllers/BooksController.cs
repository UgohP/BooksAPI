using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstApi.Data;
using MyFirstApi.Models;

namespace MyFirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly BooksContext _context;

        public BooksController(BooksContext context)
        {
            _context = context;
        }
        //static private List<Book> books = new List<Book>
        //{
        //    new Book { Id = 1, Title = "The Pragmatic Programmer", Author = "Andrew Hunt & David Thomas", YearPublished = 1999 },
        //    new Book { Id = 2, Title = "Clean Code", Author = "Robert C. Martin", YearPublished = 2008 },
        //    new Book { Id = 3, Title = "Design Patterns", Author = "Erich Gamma et al.", YearPublished = 1994 }
        //};

        [HttpGet]
        public  async Task<ActionResult<List<Book>>> GetBooks()
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
            return Ok(book);

        }

        [HttpPost]
        public async Task<ActionResult<Book>> AddBook(Book newBook)
        {
            if (newBook == null) return BadRequest();

            _context.Books.Add(newBook);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBookById), new { id = newBook.Id }, newBook);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, Book updatedBook)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return NotFound();

            book.Id = updatedBook.Id;
            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.YearPublished = updatedBook.YearPublished;

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
