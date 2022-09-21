using AspBlogSitesi.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspBlogSitesi.WebUI.Areas.Admin.Models
{
    public class ArticleUpdateViewModel
    {
        [DisplayName("Başlık")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir")]
        [MaxLength(100, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır")]
        [MinLength(5, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır")]
        public string Title { get; set; }

        [DisplayName("İçerik")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir")]
        [MinLength(5, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır")]
        public string Content { get; set; }

        [DisplayName("Resim")]
        public IFormFile ThumbnailFile { get; set; }

        [DisplayName("Resim")]
        public string Thumbnail { get; set; }

        [DisplayName("Tarih")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [DisplayName("Makale Açıklaması")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir")]
        [MaxLength(150, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır")]
        [MinLength(5, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır")]
        public string SeoDescription { get; set; }

        [DisplayName("Yazar Adı")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır")]
        [MinLength(5, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır")]
        public string SeoAuthor { get; set; }

        [DisplayName("Makale Etiketleri")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir")]
        [MaxLength(70, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır")]
        [MinLength(5, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır")]
        public string SeoTags { get; set; }

        [DisplayName("Kategori")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir")]
        public int CategoryId { get; set; }

        public IList<Category> Categories{ get; set; }

        [DisplayName("Aktif Mi?")]
        public bool IsActive { get; set; }
        [DisplayName("Silindi Mi?")]
        public bool IsDeleted { get; set; }
        [Required]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
