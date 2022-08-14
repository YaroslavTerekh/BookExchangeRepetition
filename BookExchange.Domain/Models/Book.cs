using BookExchange.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Domain.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        //[Required(ErrorMessage = "Enter title of your book!")]
        //[MaxLength(100, ErrorMessage = "Too long length of title!")]
        public string Title { get; set; }
        //[Required(ErrorMessage = "Enter title of your book!")]
        //[MaxLength(500, ErrorMessage = "Too long length of description (500 max)")]
        //[MinLength(50, ErrorMessage = "Too short length of description (50 min)")]
        public string Description { get; set; }
        //[Required(ErrorMessage = "Upload a photo of book!")]
        public Image Image { get; set; }
        public State State { get; set; }
    }
}
