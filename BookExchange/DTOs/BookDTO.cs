using BookExchange.Domain.Models;

namespace BookExchange.DTOs
{
    public class BookDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Image Image { get; set; }
        public int UserId { get; set; }
    }
}
