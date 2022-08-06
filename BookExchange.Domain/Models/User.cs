using System;
using System.Collections.Generic;

namespace BookExchange.Domain.Models
{
    public class User
    {
        // public int? ID { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public AddressInfo Address { get; set; }
        public DateTime RegisteredDate { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }

        public IEnumerable<Book> Books { get; set; }

        public bool IsBanned { get; set; }
    }
}
