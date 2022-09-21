using AspBlogSitesi.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspBlogSitesi.DataAccess.Concrete.EntityFramework.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Picture).IsRequired();
            builder.Property(u => u.Picture).HasMaxLength(250);

            builder.HasKey(u => u.Id);

            // Indexes for "normalized" username and email, to allow efficient lookups
            builder.HasIndex(u => u.NormalizedUserName).HasDatabaseName("UserNameIndex").IsUnique();
            builder.HasIndex(u => u.NormalizedEmail).HasDatabaseName("EmailIndex");

            // Maps to the AspNetUsers table
            builder.ToTable("AspNetUsers");

            // A concurrency token for use with the optimistic concurrency checking
            builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

            // Limit the size of columns to use efficient database types
            builder.Property(u => u.UserName).HasMaxLength(50);
            builder.Property(u => u.NormalizedUserName).HasMaxLength(50);
            builder.Property(u => u.Email).HasMaxLength(100);
            builder.Property(u => u.NormalizedEmail).HasMaxLength(100);

            builder.Property(u => u.Name).IsRequired();
            builder.Property(u => u.Name).HasMaxLength(50);

            builder.Property(u => u.Surname).IsRequired();
            builder.Property(u => u.Surname).HasMaxLength(50);

            builder.Property(u => u.BirthPlace).IsRequired();
            builder.Property(u => u.BirthPlace).HasMaxLength(50);

            builder.Property(u => u.Gender).IsRequired();
            builder.Property(u => u.Status).IsRequired();

            builder.Property(u => u.BirthDate).IsRequired();

            // The relationships between User and other entity types
            // Note that these relationships are configured with no navigation properties

            // Each User can have many UserClaims
            builder.HasMany<UserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

            // Each User can have many UserLogins
            builder.HasMany<UserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

            // Each User can have many UserTokens
            builder.HasMany<UserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

            // Each User can have many entries in the UserRole join table
            builder.HasMany<UserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();

            var adminUser = new User
            {
                Id = 1,
                Name = "Nurettin",
                Surname = "Ekiz",
                UserName = "ekiznurettin",
                BirthDate=Convert.ToDateTime("05.04.1993"),
                BirthPlace="AYBASTI",
                Gender=1,
                Status=1,
                Picture= "user.jpg",
                NormalizedUserName = "EKİZNURETTİN",
                Email = "ekiznurettin@gmail.com",
                NormalizedEmail = "EKİZNURETTİN@GMAİL.COM",
                PhoneNumber = "+905555555555",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),

            };
            adminUser.PasswordHash = CreatePassword(adminUser, "123456");
            var editorUser = new User
            {
                Id = 2,
                Name = "Veda Nur",
                Surname = "Ekiz",
                UserName = "ekizveda",
                BirthDate = Convert.ToDateTime("05.04.1999"),
                BirthPlace="BURSA",
                Gender = 2,
                Status = 1,
                Picture="user.jpg",
                NormalizedUserName = "EKİZVEDA",
                Email = "ekizveda@gmail.com",
                NormalizedEmail = "EKİZVEDA@GMAİL.COM",
                PhoneNumber = "+905555555555",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            editorUser.PasswordHash = CreatePassword(editorUser, "123456");
            builder.HasData(adminUser, editorUser);
        }
        private string CreatePassword(User user,string password)
        {
            var passwordHasher = new PasswordHasher<User>();
            return passwordHasher.HashPassword(user, password);
        }
    }
}
