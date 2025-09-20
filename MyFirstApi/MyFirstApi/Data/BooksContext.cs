using Microsoft.EntityFrameworkCore;
using MyFirstApi.Models;

namespace MyFirstApi.Data
{
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, Title = "The Pragmatic Programmer", Author = "Andrew Hunt & David Thomas", YearPublished = 1999 },
            new Book { Id = 2, Title = "Clean Code", Author = "Robert C. Martin", YearPublished = 2008 },
            new Book { Id = 3, Title = "Design Patterns", Author = "Erich Gamma et al.", YearPublished = 1994 }
            );
        }
        public DbSet<Book> Books { get; set; }
    }
}
