using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BookExchange.Domain.Enum;

namespace BookExchange.Domain.Models
{
    public class User
    {
        public int ID { get; set; }
        //[Required(ErrorMessage = "Enter your name!")]
        //[MaxLength(15, ErrorMessage = "Too long name!")]
        public string Name { get; set; }
        //[MaxLength(20, ErrorMessage = "Too long second name!")]
        //[Required(ErrorMessage = "Enter your second name!")]
        public string SecondName { get; set; }
        //[Required(ErrorMessage = "Enter your e-mail!")]
        public string Email { get; set; }
        //[Required]
        public AddressInfo Address { get; set; }
        public DateTime RegisteredDate { get; set; }
        //[Required]
        public string Password { get; set; }
        public Roles Role { get; set; }

        public IEnumerable<Book> Books { get; set; }

        public bool IsBanned { get; set; }
    }
}
