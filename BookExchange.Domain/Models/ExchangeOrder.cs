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
        public int FirstAddress { get; set; }
        public int FirstBookId { get; set; }
        public int SecondAddress { get; set; }
        public int SecondBookId { get; set; }

        public bool IsApproved { get; set; }
    }
}
