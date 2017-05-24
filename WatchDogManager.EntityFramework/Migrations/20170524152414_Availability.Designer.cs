using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WatchDogManager.EntityFramework;

namespace WatchDogManager.EntityFramework.Migrations
{
    [DbContext(typeof(WatchDogManagerDbContext))]
    [Migration("20170524152414_Availability")]
    partial class Availability
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

            modelBuilder.Entity("WatchDogManager.EntityFramework.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Schedule");
                });

            modelBuilder.Entity("WatchDogManager.EntityFramework.ScheduleAvailability", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("At")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsAvailable");

                    b.Property<int>("ScheduleId");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleId");

                    b.ToTable("ScheduleAvailability");
                });

            modelBuilder.Entity("WatchDogManager.EntityFramework.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Grade")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("RoomNumber")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.ToTable("Teachers");
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

            modelBuilder.Entity("WatchDogManager.EntityFramework.Schedule", b =>
                {
                    b.HasOne("WatchDogManager.EntityFramework.Teacher", "Teacher")
                        .WithMany("Schedules")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WatchDogManager.EntityFramework.ScheduleAvailability", b =>
                {
                    b.HasOne("WatchDogManager.EntityFramework.Schedule", "Schedule")
                        .WithMany("Availability")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
