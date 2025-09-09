using APIone.models;
using Microsoft.EntityFrameworkCore;

namespace APIone.Data
{
    public class FirstAPIContext : DbContext
    {
        public FirstAPIContext(DbContextOptions<FirstAPIContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().HasData(
            new Book
            {
                Id = 1,
                Author = "A1",
                Title = "T1",
                YearPublished = 2001
            },
            new Book
            {
                Id = 2,
                Author = "A2",
                Title = "T2",
                YearPublished = 2002
            },
            new Book
            {
                Id = 3,
                Author = "A3",
                Title = "T3",
                YearPublished = 2003
            },
            new Book
            {
                Id = 4,
                Author = "A4",
                Title = "T4",
                YearPublished = 2004
            },
            new Book
            {
                Id = 5,
                Author = "A5",
                Title = "T5",
                YearPublished = 2005
            }
            );
        }
        public DbSet<Book> Books { get; set; }
    }
}
