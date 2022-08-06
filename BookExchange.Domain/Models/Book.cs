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
        [Column("BookId")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Enter title of your book!")]
        [MaxLength(100, ErrorMessage = "Too long length of title!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Enter title of your book!")]
        [MaxLength(500, ErrorMessage = "Too long length of description (500 max)")]
        [MinLength(50, ErrorMessage = "Too short length of description (50 min)")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Upload a photo of book!")]
        public Image Image { get; set; }
        public User Owner { get; set; }

        public bool isApproved { get; set; }
    }
}
