using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Domain.Models
{
    public class ExchangeOrder
    {
        public int Id { get; set; }
        public Book FirstBook { get; set; }
        public Book SecondBook { get; set; }

        public bool IsApproved { get; set; }
    }
}
