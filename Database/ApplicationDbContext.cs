using DeviceRental.Models;
using System.Data.Entity;

namespace DeviceRental.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DeviceRentalConnectionString")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.UseDatabaseNullSemantics = false;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<DeviceRental.Models.DeviceRental> DeviceRentals { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>()
                .HasMany(x => x.DeviceRentals)
                .WithRequired(x => x.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Device>()
                .HasMany(x => x.DeviceRentals)
                .WithRequired(x => x.Device)
                .WillCascadeOnDelete(false);
        }
    }
}
