

using Microsoft.AspNetCore.Mvc;
using JwtAuthForBooks.Models;
using System.Linq;
using Microsoft.AspNetCore.OData.Query;
using System;
using Microsoft.AspNetCore.Authorization;

namespace JwtAuthForBooks.Controllers
{
    [Route("odata/[controller]")]
    [ApiController]
    [Authorize] // Tüm işlemleri kimlik doğrulama gerektiren bir controller olarak ayarla
    public class BookController : ControllerBase
    {
        private readonly YourDbContext _context;
        public BookController(YourDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {
            var allBookInformations = _context.BookInformations;
            return Ok(allBookInformations);
        }

        [HttpGet("{id}")]
        [EnableQuery]
        public IActionResult GetById(int id)
        {
            var bookInformation = _context.BookInformations.FirstOrDefault(b => b.BookId == id);

            if (bookInformation == null)
            {
                return NotFound();
            }

            return Ok(bookInformation);
        }

        // Diğer action'lar buraya eklenebilir

        [HttpPost]
        
        [Authorize(Roles = "Admin")] // Sadece "admin" rolüne sahip kullanıcılar bu işlemi yapabilir
        public IActionResult CreateBook(BookInformations book)
        {
            // Yeni bir kitap eklemek için gereken kodları burada yazın
            // Örnek olarak kitap ekleme kodları

            _context.BookInformations.Add(book);
            _context.SaveChanges();

            return Ok(book);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")] // Sadece "admin" rolüne sahip kullanıcılar bu işlemi yapabilir
        public IActionResult DeleteBook(int id)
        {
            var BookInformations = _context.BookInformations.FirstOrDefault(b => b.BookId == id);

            if (BookInformations == null)
            {
                return NotFound();
            }

            _context.BookInformations.Remove(BookInformations);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
