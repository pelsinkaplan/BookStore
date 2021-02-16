using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        [Display(Name = "Yayınevinin Adı")]
        public string Name { get; set; }
        [Display(Name = "Resim")]
        public string Image { get; set; }
        [Display(Name = "Kitaplar")]
        public IList<Book> Books { get; set; }
    }
}
