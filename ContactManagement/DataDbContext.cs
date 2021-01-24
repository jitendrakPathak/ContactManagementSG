using ContactManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;

namespace ContactManagement
{

    public class DataDbContext : DbContext
    {
        public DataDbContext()
        {
        }


        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {
        }

        public virtual DbSet<ContactModel> Contacts { get; set; }
        public virtual DbSet<PhoneNumberModel> PhoneNumber { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            builder.Entity<ContactModel>(e =>
            {
                e.HasKey("Id");
                e.ToTable("Contact", "dbo");
            });
            builder.Entity<PhoneNumberModel>(e =>
            {
                e.HasKey("Id");
                e.ToTable("PhoneNumber", "dbo");
            });
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}