using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Lütfen kitabın adını giriniz!")]
        [Display(Name = "Ad")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Lütfen kitabın resim uzantısını giriniz!")]
        [Display(Name = "Resim")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Lütfen kitabın fiyatını giriniz!")]
        [Display(Name = "Fiyat")]
        public double? Price { get; set; }
        [Required(ErrorMessage = "Lütfen kitabın içeriğini giriniz!")]
        [Display(Name = "İçerik")]
        public string Content { get; set; }
        [Required(ErrorMessage = "Lütfen kitabın sayfa sayısını giriniz!")]
        [Display(Name = "Sayfa Sayısı")]
        public int? PageNumber { get; set; }
        [Required(ErrorMessage = "Lütfen kitabın kazandırdığı puanı giriniz!")]
        [Display(Name = "Kazandırdığı Puan")]
        public int? Point { get; set; }
        [Required(ErrorMessage = "Lütfen kitabın puanını giriniz!")]
        [Display(Name = "Puan")]
        public double? Rating { get; set; }
        [Required(ErrorMessage = "Lütfen kitabın yayınlanma tarihini giriniz!")]
        [Display(Name = "Yayınlanma Tarihi")]
        public DateTime? ReleaseDate { get; set; }
        [Required(ErrorMessage = "Lütfen kitabın indirim oranını giriniz!")]
        [Display(Name = "İndirim Oranı")]
        public int? DiscountRate { get; set; }
        [Required(ErrorMessage = "Lütfen kitabın satılma sayısını giriniz!")]
        [Display(Name = "Satılma Sayısı")]
        public int? SoldNumber { get; set; }

        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Display(Name = "Yayınevi")]
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        [Display(Name = "Yazar")]
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        [Display(Name = "Yorumlar")]
        public IList<Comment> Comments { get; set; }
    }
}
