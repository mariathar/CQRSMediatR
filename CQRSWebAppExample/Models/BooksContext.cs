using CQRSWebAppExample.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace CQRSWebAppExample
{

    public interface IBooksContext
	{

	}


    public class BooksContext : DbContext, IBooksContext
    {
        public DbSet<Book> Books { get; set; }

        public BooksContext(DbContextOptions<BooksContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}