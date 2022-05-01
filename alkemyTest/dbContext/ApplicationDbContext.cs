using alkemyTest.Models;
using Microsoft.EntityFrameworkCore;

namespace alkemyTest.dbContext
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<MovieSerie> MovieSeries { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Character> Characters { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // On model creating function will provide us with the ability to manage the tables properties
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
