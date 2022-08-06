using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Domain.Models
{
    public class ExchangeOrder
    {
        // public int? ID { get; set; }
        public string FirstAddress { get; set; }
        public Book FirstBook { get; set; }
        public string SecondAddress { get; set; }
        public Book SecondBook { get; set; }

        public bool IsApproved { get; set; } = false;
    }
}
