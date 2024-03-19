using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.API.Data;

public partial class BookStoreDbContext : IdentityDbContext<ApiUser>
{
    public BookStoreDbContext()
    {
    }

    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Authors__3214EC07F613F2F9");

            entity.Property(e => e.Bio).HasMaxLength(250);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Books__3214EC07EE982BC4");

            entity.HasIndex(e => e.Isbn, "UQ__Books__9271CED0B5F40FA2").IsUnique();

            entity.Property(e => e.Isbn).HasMaxLength(20);
            entity.Property(e => e.Summary).HasMaxLength(60);
            entity.Property(e => e.Title).HasMaxLength(30);

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK_Books_ToTable");
        });

        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER",
                Id = "86c67d25-97c3-4ccf-b229-e7ac084f2268"
            },
            new IdentityRole
            {
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                Id = "cb0c558c-89c5-4f1a-bfbf-32dff3c2990a"
            }

        );

        PasswordHasher<ApiUser> hasher = new();

        modelBuilder.Entity<ApiUser>().HasData(

            new ApiUser
            {
                Id = "d91ae632-e1a2-4cdd-a84e-97572a377f1d",
                Email = "admin@bookstore.com",
                NormalizedEmail = "ADMIN@BOOKSTORE.COM",
                UserName = "admin@bookstore.com",
                NormalizedUserName = "ADMIN@BOOKSTORE.COM",
                FirstName = "System",
                LastName = "Admin",
                PasswordHash = hasher.HashPassword(null, "P@$$word1")
            },
            new ApiUser
            {
                Id = "8175218f-81db-44df-8580-07e8ac1e62df",
                Email = "user@bookstore.com",
                NormalizedEmail = "USER@BOOKSTORE.COM",
                UserName = "user@bookstore.com",
                NormalizedUserName = "USER@BOOKSTORE.COM",
                FirstName = "System",
                LastName = "User",
                PasswordHash = hasher.HashPassword(null, "P@$$word1")
            }
        );

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "86c67d25-97c3-4ccf-b229-e7ac084f2268",
                UserId = "8175218f-81db-44df-8580-07e8ac1e62df"
            },
            new IdentityUserRole<string>
            {
                RoleId = "cb0c558c-89c5-4f1a-bfbf-32dff3c2990a",
                UserId = "d91ae632-e1a2-4cdd-a84e-97572a377f1d"
            }
        );

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
