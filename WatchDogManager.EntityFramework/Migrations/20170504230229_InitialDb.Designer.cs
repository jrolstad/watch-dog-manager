using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WatchDogManager.EntityFramework;

namespace WatchDogManager.EntityFramework.Migrations
{
    [DbContext(typeof(WatchDogManagerDbContext))]
    [Migration("20170504230229_InitialDb")]
    partial class InitialDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WatchDogManager.EntityFramework.CalendarDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("VolunteerId");

                    b.HasKey("Id");

                    b.HasIndex("VolunteerId");

                    b.ToTable("CalendarDays");
                });

            modelBuilder.Entity("WatchDogManager.EntityFramework.Volunteer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("BackgroundCheck")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("Students")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Teachers")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Volunteers");
                });

            modelBuilder.Entity("WatchDogManager.EntityFramework.CalendarDay", b =>
                {
                    b.HasOne("WatchDogManager.EntityFramework.Volunteer", "Volunteer")
                        .WithMany("DaysSignedUp")
                        .HasForeignKey("VolunteerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
