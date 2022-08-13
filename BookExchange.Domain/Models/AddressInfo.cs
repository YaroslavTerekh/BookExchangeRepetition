﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Domain.Models
{
    public class AddressInfo
    {
        public Guid Id { get; set; }
        //[Required(ErrorMessage = "Enter your country!")]
        public string Country { get; set; }
        //[Required(ErrorMessage = "Enter your city!")]
        public string City { get; set; }
        //[Required(ErrorMessage = "Enter your post index!")]
        public string PostIndex { get; set; }
    }
}
