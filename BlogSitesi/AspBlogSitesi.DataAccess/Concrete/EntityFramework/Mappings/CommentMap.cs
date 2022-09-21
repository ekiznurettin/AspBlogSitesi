using AspBlogSitesi.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspBlogSitesi.DataAccess.Concrete.EntityFramework.Mappings
{
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Text).HasColumnName("NVARCHAR(MAX)");
            builder.Property(c => c.Text).IsRequired();

            builder.Property(c => c.CreatedByName).HasMaxLength(50);
            builder.Property(c => c.CreatedByName).IsRequired();
            builder.Property(c => c.ModifiedByName).HasMaxLength(100);
            builder.Property(c => c.ModifiedByName).IsRequired();
            builder.Property(c => c.CreatedDate).IsRequired();
            builder.Property(c => c.ModifiedDate).IsRequired();
            builder.Property(c => c.IsActive).IsRequired();
            builder.Property(c => c.IsDeleted).IsRequired();
            builder.Property(c => c.Note).HasMaxLength(500);

            builder.HasOne<Article>(c => c.Article).WithMany(a => a.Comments).HasForeignKey(c => c.ArticleId);

            builder.ToTable("Comments");

            //builder.HasData(new Comment
            //{
            //    Id = 1,
            //    Text= "1500'lerden beri kullanılmakta olan standard Lorem Ipsum metinleri ilgilenenler için yeniden üretilmiştir. Çiçero tarafından yazılan 1.10.32 ve 1.10.33 bölümleri de 1914 H. Rackham çevirisinden alınan İngilizce sürümleri eşliğinde özgün biçiminden yeniden üretilmiştir.",
            //    ArticleId=1,
            //    IsActive = true,
            //    IsDeleted = false,
            //    CreatedByName = "Initial Create",
            //    CreatedDate = DateTime.Now,
            //    ModifiedByName = "Initial Create",
            //    ModifiedDate = DateTime.Now,
            //    Note = "C# Makale Yorumu"
            //}, new Comment
            //{
            //    Id = 2,
            //    Text = "1500'lerden beri kullanılmakta olan standard Lorem Ipsum metinleri ilgilenenler için yeniden üretilmiştir. Çiçero tarafından yazılan 1.10.32 ve 1.10.33 bölümleri de 1914 H. Rackham çevirisinden alınan İngilizce sürümleri eşliğinde özgün biçiminden yeniden üretilmiştir.",
            //    ArticleId = 2,
            //    IsActive = true,
            //    IsDeleted = false,
            //    CreatedByName = "Initial Create",
            //    CreatedDate = DateTime.Now,
            //    ModifiedByName = "Initial Create",
            //    ModifiedDate = DateTime.Now,
            //    Note = "C++ Makale Yorumu"
            //},
            //new Comment
            //{
            //    Id = 3,
            //    Text = "1500'lerden beri kullanılmakta olan standard Lorem Ipsum metinleri ilgilenenler için yeniden üretilmiştir. Çiçero tarafından yazılan 1.10.32 ve 1.10.33 bölümleri de 1914 H. Rackham çevirisinden alınan İngilizce sürümleri eşliğinde özgün biçiminden yeniden üretilmiştir.",
            //    ArticleId = 3,
            //    IsActive = true,
            //    IsDeleted = false,
            //    CreatedByName = "Initial Create",
            //    CreatedDate = DateTime.Now,
            //    ModifiedByName = "Initial Create",
            //    ModifiedDate = DateTime.Now,
            //    Note = "Java Makale Yorumu"
            //}) ;
        }
    }
}
