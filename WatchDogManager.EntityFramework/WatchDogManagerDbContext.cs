using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WatchDogManager.EntityFramework
{
    public class WatchDogManagerDbContext:DbContext
    {
        private readonly string _connectionString;

        public WatchDogManagerDbContext() : this(ConfigurationManager.ConnectionStrings["WatchDogManagerDatabase"].ConnectionString)
        {

        }

        public WatchDogManagerDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Volunteer>(entity =>
            {
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Phone).IsRequired().HasMaxLength(25);
                entity.Property(e => e.Students).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Teachers).IsRequired().HasMaxLength(100);
                entity.Property(e => e.BackgroundCheck).HasColumnType("datetime");
                
            });

            modelBuilder.Entity<CalendarDay>(entity =>
            {
                entity.Property(e => e.Date).IsRequired().HasColumnType("datetime");
                entity.Property(e => e.Title).IsRequired().HasMaxLength(100);
                entity.HasOne(e => e.Volunteer).WithMany(e=>e.DaysSignedUp).HasForeignKey(e => e.VolunteerId);
            });


            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Volunteer> Volunteers { get; set; }

        public virtual DbSet<CalendarDay> CalendarDays { get; set; }
    }
}
