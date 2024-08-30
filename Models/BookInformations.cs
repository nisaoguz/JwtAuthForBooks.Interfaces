

using System.ComponentModel.DataAnnotations;

namespace JwtAuthForBooks.Models
{
    public class BookInformations
    {
        [Key] // Anahtar alanı belirtiyoruz
        public int BookId { get; set; }

        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AuthorName { get; set; }
    }
}
