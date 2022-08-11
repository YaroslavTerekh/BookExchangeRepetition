namespace BookExchange.DTOs
{
    public class ExchangeOrderDTO
    {
        public int Id { get; set; }
        public BookDTO FirstBook { get; set; }
        public BookDTO SecondBook { get; set; }
    }
}
