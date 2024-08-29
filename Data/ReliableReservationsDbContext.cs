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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Customer entity
            modelBuilder.Entity<Customer>()
                .HasKey(c => c.CustomerId); // Primary key

            // Define required fields for Customer
            modelBuilder.Entity<Customer>()
                .Property(c => c.FirstName)
                .IsRequired() // Required field
                .HasMaxLength(50); // Max length

            modelBuilder.Entity<Customer>()
                .Property(c => c.LastName)
                .IsRequired() // Required field
                .HasMaxLength(50); // Max length

            modelBuilder.Entity<Customer>()
                .Property(c => c.PhoneNumber)
                .IsRequired() // Required field
                .HasMaxLength(15); // Max length

            modelBuilder.Entity<Customer>()
                .Property(c => c.Email)
                .IsRequired() // Required field
                .HasMaxLength(100); // Max length

            // Menu entity
            modelBuilder.Entity<Menu>()
                .HasKey(m => m.MenuItemId); // Primary key

            // Define required fields for Menu
            modelBuilder.Entity<Menu>()
                .Property(m => m.Name)
                .IsRequired() // Required field
                .HasMaxLength(100); // Max length

            modelBuilder.Entity<Menu>()
                .Property(m => m.Description)
                .IsRequired() // Required field
                .HasMaxLength(500); // Max length

            modelBuilder.Entity<Menu>()
                .Property(m => m.Price)
                .IsRequired() // Required field
                .HasColumnType("decimal(18,2)"); // Column type for currency

            modelBuilder.Entity<Menu>()
                .Property(m => m.Category)
                .IsRequired() // Required field
                .HasMaxLength(50); // Max length

            // OpeningHours entity
            modelBuilder.Entity<OpeningHours>()
                .HasKey(o => o.OpeningHoursId); // Primary key

            // Define required fields for OpeningHours
            modelBuilder.Entity<OpeningHours>()
                .Property(o => o.DayOfWeek)
                .IsRequired(); // Required field

            modelBuilder.Entity<OpeningHours>()
                .Property(o => o.OpenTime)
                .IsRequired(); // Required field

            modelBuilder.Entity<OpeningHours>()
                .Property(o => o.CloseTime)
                .IsRequired(); // Required field

            modelBuilder.Entity<OpeningHours>()
                .Property(o => o.IsClosed)
                .IsRequired(); // Required field

            // Define relationships for OpeningHours
            modelBuilder.Entity<OpeningHours>()
                .HasMany(o => o.TimeSlots) // One-to-many relationship with TimeSlot
                .WithOne(t => t.OpeningHours)
                .HasForeignKey(t => t.OpeningHoursId); // Foreign key in TimeSlot

            // SpecialOpeningHours entity
            modelBuilder.Entity<SpecialOpeningHours>()
                .HasKey(s => s.SpecialOpeningHoursId); // Primary key

            // Define required fields for SpecialOpeningHours
            modelBuilder.Entity<SpecialOpeningHours>()
                .Property(s => s.Date)
                .IsRequired(); // Required field

            modelBuilder.Entity<SpecialOpeningHours>()
                .Property(s => s.OpenTime)
                .IsRequired(false); // Optional field

            modelBuilder.Entity<SpecialOpeningHours>()
                .Property(s => s.CloseTime)
                .IsRequired(false); // Optional field

            modelBuilder.Entity<SpecialOpeningHours>()
                .Property(s => s.IsClosed)
                .IsRequired(); // Required field

            // Define relationships for SpecialOpeningHours
            modelBuilder.Entity<SpecialOpeningHours>()
                .HasOne(s => s.OpeningHours) // Many-to-one relationship with OpeningHours
                .WithMany(o => o.SpecialOpeningHours)
                .HasForeignKey(s => s.OpeningHoursId); // Foreign key in SpecialOpeningHours

            // Reservation entity
            modelBuilder.Entity<Reservation>()
                .HasKey(r => r.ReservationId); // Primary key

            // Define relationships for Reservation
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Customer) // Many-to-one relationship with Customer
                .WithMany(c => c.Reservations)
                .HasForeignKey(r => r.CustomerId); // Foreign key in Reservation

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.TimeSlot) // Many-to-one relationship with TimeSlot
                .WithMany(t => t.Reservations)
                .HasForeignKey(r => r.TimeSlotId); // Foreign key in Reservation

            modelBuilder.Entity<Reservation>()
                .HasMany(r => r.Tables) // Many-to-many relationship with Table
                .WithMany(t => t.Reservations)
                .UsingEntity(j => j.ToTable("ReservationTables")); // Junction table

            modelBuilder.Entity<Reservation>()
                .Property(r => r.NumberOfGuests)
                .IsRequired() // Required field
                .HasDefaultValue(1); // Default value

            modelBuilder.Entity<Reservation>()
                .Property(r => r.SpecialRequests)
                .HasMaxLength(300); // Max length

            // Table entity
            modelBuilder.Entity<Table>()
                .HasKey(t => t.TableId); // Primary key

            // Define required fields for Table
            modelBuilder.Entity<Table>()
                .Property(t => t.TableNumber)
                .IsRequired(); // Required field

            modelBuilder.Entity<Table>()
                .Property(t => t.SeatingCapacity)
                .IsRequired(); // Required field

            modelBuilder.Entity<Table>()
                .Property(t => t.Location)
                .HasMaxLength(50); // Max length

            // TimeSlot entity
            modelBuilder.Entity<TimeSlot>()
                .HasKey(t => t.TimeSlotId); // Primary key

            // Define required fields for TimeSlot
            modelBuilder.Entity<TimeSlot>()
                .Property(t => t.StartTime)
                .IsRequired(); // Required field

            modelBuilder.Entity<TimeSlot>()
                .Property(t => t.EndTime)
                .IsRequired(); // Required field

            modelBuilder.Entity<TimeSlot>()
                .Property(t => t.SlotDuration)
                .IsRequired(); // Required field

            // Define relationships for TimeSlot
            modelBuilder.Entity<TimeSlot>()
                .HasOne(t => t.OpeningHours) // Many-to-one relationship with OpeningHours
                .WithMany(o => o.TimeSlots)
                .HasForeignKey(t => t.OpeningHoursId); // Foreign key in TimeSlot

            modelBuilder.Entity<TimeSlot>()
                .HasMany(t => t.Reservations) // One-to-many relationship with Reservation
                .WithOne(r => r.TimeSlot)
                .HasForeignKey(r => r.TimeSlotId); // Foreign key in Reservation
        }
    }
}