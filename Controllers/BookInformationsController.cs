using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JwtAuthForBooks.Models;
using System.Linq;

namespace JwtAuthForBooks.Controllers
{
    [Route("odata/[controller]")]
    [ApiController]
    public class BookInformationsController : ControllerBase
    {
        private readonly YourDbContext _context;

        public BookInformationsController(YourDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {
            var bookInformations = _context.BookInformations.AsQueryable();
            return Ok(bookInformations);
        }
    }
}
