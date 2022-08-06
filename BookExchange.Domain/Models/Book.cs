using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Domain.Models
{
    public class Book
    {
        //public int? ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Image Image { get; set; }
        public User Owner { get; set; }

        public bool isApproved { get; set; }
    }
}
