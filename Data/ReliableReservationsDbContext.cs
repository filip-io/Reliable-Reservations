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
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Customer entity
            // Define primary key
            modelBuilder.Entity<Customer>()
                .HasKey(c => c.CustomerId);

            // Define required fields
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

            // Menu entity
            // Define primary key
            modelBuilder.Entity<Menu>()
                .HasKey(m => m.MenuItemId);

            // Define required fields
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

            // OpeningHours entity
            // Define primary key
            modelBuilder.Entity<OpeningHours>()
                .HasKey(o => o.OpeningHoursId);

            // Define required fields
            modelBuilder.Entity<OpeningHours>()
                .Property(o => o.DayOfWeek)
                .IsRequired();

            modelBuilder.Entity<OpeningHours>()
                .Property(o => o.OpenTime)
                .IsRequired();

            modelBuilder.Entity<OpeningHours>()
                .Property(o => o.CloseTime)
                .IsRequired();

            modelBuilder.Entity<OpeningHours>()
                .Property(o => o.IsClosed)
                .IsRequired();

            // Define relationships with TimeSlot
            modelBuilder.Entity<OpeningHours>()
                .HasMany(o => o.TimeSlots)
                .WithOne(t => t.OpeningHours)
                .HasForeignKey(t => t.OpeningHoursId);

            // Reservation entity
            // Define primary key
            modelBuilder.Entity<Reservation>()
                .HasKey(r => r.ReservationId);

            // Define relationships with Customer and TimeSlot
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Customer)
                .WithMany(c => c.Reservations)
                .HasForeignKey(r => r.CustomerId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.TimeSlot)
                .WithMany(t => t.Reservations)
                .HasForeignKey(r => r.TimeSlotId);

            // Define many-to-many relationship with Table
            modelBuilder.Entity<Reservation>()
                .HasMany(r => r.Tables)
                .WithMany(t => t.Reservations)
                .UsingEntity(j => j.ToTable("ReservationTables"));

            // Define additional properties
            modelBuilder.Entity<Reservation>()
                .Property(r => r.NumberOfGuests)
                .IsRequired()
                .HasDefaultValue(1);

            modelBuilder.Entity<Reservation>()
                .Property(r => r.SpecialRequests)
                .HasMaxLength(300);

            // Table entity
            // Define primary key
            modelBuilder.Entity<Table>()
                .HasKey(t => t.TableId);

            // Define required fields
            modelBuilder.Entity<Table>()
                .Property(t => t.TableNumber)
                .IsRequired();

            modelBuilder.Entity<Table>()
                .Property(t => t.SeatingCapacity)
                .IsRequired();

            modelBuilder.Entity<Table>()
                .Property(t => t.Location)
                .HasMaxLength(50);

            // TimeSlot entity
            // Define primary key
            modelBuilder.Entity<TimeSlot>()
                .HasKey(t => t.TimeSlotId);

            // Define required fields
            modelBuilder.Entity<TimeSlot>()
                .Property(t => t.StartTime)
                .IsRequired();

            modelBuilder.Entity<TimeSlot>()
                .Property(t => t.EndTime)
                .IsRequired();

            modelBuilder.Entity<TimeSlot>()
                .Property(t => t.SlotDuration)
                .IsRequired();

            // Define relationships with OpeningHours and Reservation
            modelBuilder.Entity<TimeSlot>()
                .HasOne(t => t.OpeningHours)
                .WithMany(o => o.TimeSlots)
                .HasForeignKey(t => t.OpeningHoursId);

            modelBuilder.Entity<TimeSlot>()
                .HasMany(t => t.Reservations)
                .WithOne(r => r.TimeSlot)
                .HasForeignKey(r => r.TimeSlotId);
        }
    }
}