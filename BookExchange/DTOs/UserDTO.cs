namespace BookExchange.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public AddressInfoDTO Address { get; set; }
        public IEnumerable<BookDTO> Books { get; set; }
    }
}
