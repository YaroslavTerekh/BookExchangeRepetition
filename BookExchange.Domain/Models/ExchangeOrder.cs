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
        public Guid Id { get; set; }
        public Guid FirstBookId { get; set; }
        public Guid SecondBookId { get; set; }

        public bool IsApproved { get; set; }
    }
}
