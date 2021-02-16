using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Display(Name = "Yorum")]
        public string CommentString { get; set; }

        [Display(Name = "Kitap")]
        public int BookId { get; set; }
        [Display(Name = "Kitap")]
        public Book Book { get; set; }
    }
}
