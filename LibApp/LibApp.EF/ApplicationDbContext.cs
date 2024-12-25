using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibApp.Core.Models;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Emit;

namespace LibApp.EF
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options) : base(options)
        {  
        }


        /*
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            var superAdminId = Guid.NewGuid().ToString();
            var adminId = Guid.NewGuid().ToString();
            var userId = Guid.NewGuid().ToString();
            var readerId = Guid.NewGuid().ToString();

            modelbuilder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = userId,
                    Name = RoleName.NormalUser,
                    NormalizedName = RoleName.NormalUser.ToLower(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new IdentityRole()
                {
                    Id = adminId,
                    Name = RoleName.Admin,
                    NormalizedName = RoleName.Admin.ToLower(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new IdentityRole()
                {
                    Id = superAdminId,
                    Name = RoleName.SuperAdmin,
                    NormalizedName = RoleName.SuperAdmin.ToLower(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new IdentityRole()
                {
                    Id = readerId,
                    Name = RoleName.Reader,
                    NormalizedName = RoleName.Reader.ToLower(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                }
                
            );
            base.OnModelCreating(modelbuilder);
        }*/

        public DbSet<Book> Books { get; set; }
        public DbSet<Classify> Classifies { get; set; }
        public DbSet<Classification> Classifications { get; set; }
        public DbSet<Reading> Readings { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorReview> AuthorReviews { get; set; }
        public DbSet<BookReview> BookReviews { get; set; }
        public DbSet<Voice> Voices { get; set; }
        public DbSet<Tab> Tabs { get; set; }
        public DbSet<Voice_Tab> Voices_Tabs { get; set; }
        public DbSet<AuthorComment> AuthorComments { get; set; }
        public DbSet<Book_Author> Books_Authors { get; set; }
        public DbSet<BookComment> BookComments { get; set; }
        public DbSet<Lestening> Lestenings { get; set; }
    }
}
