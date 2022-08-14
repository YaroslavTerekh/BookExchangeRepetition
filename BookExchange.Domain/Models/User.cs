using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BookExchange.Domain.Enum;
using Microsoft.AspNetCore.Identity;

namespace BookExchange.Domain.Models
{
    public class User : IdentityUser<Guid>
    {
        //[Required(ErrorMessage = "Enter your name!")]
        //[MaxLength(15, ErrorMessage = "Too long name!")]
        public string FirstName { get; set; }
        //[MaxLength(20, ErrorMessage = "Too long second name!")]
        //[Required(ErrorMessage = "Enter your second name!")]
        public string LastName { get; set; }
        //[Required(ErrorMessage = "Enter your e-mail!")]
        //[Required]
        public AddressInfo AddressInfo { get; set; }
        //[Required]
        public Roles Role { get; set; }
    }
}
