using Microsoft.EntityFrameworkCore;
using Reliable_Reservations.Models;

namespace Reliable_Reservations.Data
{
    public class ReliableReservationsDbContext : DbContext
    {
        public ReliableReservationsDbContext(DbContextOptions<ReliableReservationsDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<OpeningHours> OpeningHours { get; set; }
        public DbSet<SpecialOpeningHours> SpecialOpeningHours { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }


        // Config of entities with Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Customer
            modelBuilder.Entity<Customer>()
                .HasKey(c => c.CustomerId);

            modelBuilder.Entity<Customer>()
                .Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Customer>()
                .Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Customer>()
                .Property(c => c.PhoneNumber)
                .IsRequired()
                .HasMaxLength(15);

            modelBuilder.Entity<Customer>()
                .Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);

            // Menu
            modelBuilder.Entity<Menu>()
                .HasKey(m => m.MenuItemId);

            modelBuilder.Entity<Menu>()
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Menu>()
                .Property(m => m.Description)
                .IsRequired()
                .HasMaxLength(500);

            modelBuilder.Entity<Menu>()
                .Property(m => m.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Menu>()
                .Property(m => m.Category)
                .IsRequired()
                .HasMaxLength(50);

            // OpeningHours
            modelBuilder.Entity<OpeningHours>()
                .HasKey(o => o.OpeningHoursId);

            modelBuilder.Entity<OpeningHours>()
                .Property(o => o.DayOfWeek)
                .IsRequired();

            modelBuilder.Entity<OpeningHours>()
                .Property(o => o.OpenTime)
                .IsRequired()
                .HasColumnType("time(0)");

            modelBuilder.Entity<OpeningHours>()
                .Property(o => o.CloseTime)
                .IsRequired()
                .HasColumnType("time(0)");

            modelBuilder.Entity<OpeningHours>()
                .Property(o => o.IsClosed)
                .IsRequired();

            modelBuilder.Entity<OpeningHours>()
                .HasMany(o => o.TimeSlots)
                .WithOne(t => t.OpeningHours)
                .HasForeignKey(t => t.OpeningHoursId);

            // SpecialOpeningHours
            modelBuilder.Entity<SpecialOpeningHours>()
                .HasKey(s => s.SpecialOpeningHoursId);

            modelBuilder.Entity<SpecialOpeningHours>()
                .Property(s => s.Date)
                .IsRequired();

            modelBuilder.Entity<SpecialOpeningHours>()
                .Property(s => s.OpenTime)
                .IsRequired(false)
                .HasColumnType("time(0)");

            modelBuilder.Entity<SpecialOpeningHours>()
                .Property(s => s.CloseTime)
                .IsRequired(false)
                .HasColumnType("time(0)");

            modelBuilder.Entity<SpecialOpeningHours>()
                .Property(s => s.IsClosed)
                .IsRequired();

            modelBuilder.Entity<SpecialOpeningHours>()
                .HasOne(s => s.OpeningHours)
                .WithMany(o => o.SpecialOpeningHours)
                .HasForeignKey(s => s.OpeningHoursId);

            // Reservation
            modelBuilder.Entity<Reservation>()
                .HasKey(r => r.ReservationId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Customer)
                .WithMany(c => c.Reservations)
                .HasForeignKey(r => r.CustomerId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.TimeSlot)
                .WithMany(t => t.Reservations)
                .HasForeignKey(r => r.TimeSlotId);

            modelBuilder.Entity<Reservation>()
                .Property(r => r.ReservationDate)
                .IsRequired()
                .HasColumnType("datetime2(0)");

            modelBuilder.Entity<Reservation>()
                .HasMany(r => r.Tables)
                .WithMany(t => t.Reservations)
                .UsingEntity<Dictionary<string, object>>
                (
                    "ReservationTables",
                    j => j
                        .HasOne<Table>()
                        .WithMany()
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j
                        .HasOne<Reservation>()
                        .WithMany()
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                );

            modelBuilder.Entity<Reservation>()
                .Property(r => r.NumberOfGuests)
                .IsRequired()
                .HasDefaultValue(1);

            modelBuilder.Entity<Reservation>()
                .Property(r => r.SpecialRequests)
                .HasMaxLength(300);

            // Table
            modelBuilder.Entity<Table>()
                .HasKey(t => t.TableId);

            modelBuilder.Entity<Table>()
                .Property(t => t.TableNumber)
                .IsRequired();

            modelBuilder.Entity<Table>()
                .Property(t => t.SeatingCapacity)
                .IsRequired();

            modelBuilder.Entity<Table>()
                .Property(t => t.Location)
                .HasMaxLength(50);

            modelBuilder.Entity<Table>()
                .HasIndex(t => t.TableNumber)
                .IsUnique();

            // TimeSlot
            modelBuilder.Entity<TimeSlot>()
                .HasKey(t => t.TimeSlotId);

            modelBuilder.Entity<TimeSlot>()
                .Property(t => t.StartTime)
                .IsRequired()
                .HasColumnType("datetime2(0)");

            modelBuilder.Entity<TimeSlot>()
                .Property(t => t.EndTime)
                .IsRequired()
                .HasColumnType("datetime2(0)");


            modelBuilder.Entity<TimeSlot>()
                .Property(t => t.SlotDuration)
                .IsRequired();

            modelBuilder.Entity<TimeSlot>()
                .HasOne(t => t.OpeningHours)
                .WithMany(o => o.TimeSlots)
                .HasForeignKey(t => t.OpeningHoursId);

            modelBuilder.Entity<TimeSlot>()
                .HasMany(t => t.Reservations)
                .WithOne(r => r.TimeSlot)
                .HasForeignKey(r => r.TimeSlotId);

            // Seed data for OpeningHours
            modelBuilder.Entity<OpeningHours>().HasData
                (
                    new OpeningHours
                    {
                        OpeningHoursId = 1,
                        DayOfWeek = DayOfWeek.Sunday,
                        OpenTime = new TimeOnly(10, 0),
                        CloseTime = new TimeOnly(23, 0),
                        IsClosed = false
                    },
                    new OpeningHours
                    {
                        OpeningHoursId = 2,
                        DayOfWeek = DayOfWeek.Monday,
                        OpenTime = new TimeOnly(10, 0),
                        CloseTime = new TimeOnly(23, 0),
                        IsClosed = true
                    },
                    new OpeningHours
                    {
                        OpeningHoursId = 3,
                        DayOfWeek = DayOfWeek.Tuesday,
                        OpenTime = new TimeOnly(10, 0),
                        CloseTime = new TimeOnly(23, 0),
                        IsClosed = true
                    },
                    new OpeningHours
                    {
                        OpeningHoursId = 4,
                        DayOfWeek = DayOfWeek.Wednesday,
                        OpenTime = new TimeOnly(10, 0),
                        CloseTime = new TimeOnly(23, 0),
                        IsClosed = false
                    },
                    new OpeningHours
                    {
                        OpeningHoursId = 5,
                        DayOfWeek = DayOfWeek.Thursday,
                        OpenTime = new TimeOnly(10, 0),
                        CloseTime = new TimeOnly(23, 0),
                        IsClosed = false
                    },
                    new OpeningHours
                    {
                        OpeningHoursId = 6,
                        DayOfWeek = DayOfWeek.Friday,
                        OpenTime = new TimeOnly(10, 0),
                        CloseTime = new TimeOnly(23, 0),
                        IsClosed = false
                    },
                    new OpeningHours
                    {
                        OpeningHoursId = 7,
                        DayOfWeek = DayOfWeek.Saturday,
                        OpenTime = new TimeOnly(10, 0),
                        CloseTime = new TimeOnly(23, 0),
                        IsClosed = false
                    }
                );
        }
    }
}