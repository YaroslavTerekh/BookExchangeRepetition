namespace BookExchange.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ImageDTO Image { get; set; }
        public UserDTO Owner { get; set; }
    }
}
