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
        public string FirstAddress { get; set; }
        public int FirstBookId { get; set; }
        public string SecondAddress { get; set; }
        public int SecondBookId { get; set; }

        public bool IsApproved { get; set; }
    }
}
