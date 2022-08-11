namespace BookExchange.DTOs
{
    public class ExchangeOrderDTO
    {
        public int Id { get; set; }
        public AddressInfoDTO FirstAddress { get; set; }
        public BookDTO FirstBook { get; set; }
        public AddressInfoDTO SecondAddress { get; set; }
        public BookDTO SecondBook { get; set; }
    }
}
