namespace BookExchange.DTOs
{
    public class ExchangeOrderDTO
    {
        public int Id { get; set; }
        public string FirstAddress { get; set; }
        public int FirstBookId { get; set; }
        public string SecondAddress { get; set; }
        public int SecondBookId { get; set; }
    }
}
