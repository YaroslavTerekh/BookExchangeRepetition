namespace BookExchange.Domain.DTOs
{
    public class ExchangeOrderDTO
    {
        public BookDTO FirstBook { get; set; }
        public BookDTO SecondBook { get; set; }
    }
}
