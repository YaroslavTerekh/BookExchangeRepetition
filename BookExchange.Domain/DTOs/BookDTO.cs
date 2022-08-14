namespace BookExchange.Domain.DTOs
{
    public class BookDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ImageDTO Image { get; set; }
        public Guid UserId { get; set; }
    }
}
