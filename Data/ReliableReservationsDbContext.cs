using Microsoft.EntityFrameworkCore;
using Reliable_Reservations.Models;

namespace Reliable_Reservations.Data
{
    public class ReliableReservationsDbContext : DbContext
    {
        public ReliableReservationsDbContext(DbContextOptions<ReliableReservationsDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
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


            // MenuItem
            modelBuilder.Entity<MenuItem>()
                .HasKey(m => m.MenuItemId);

            modelBuilder.Entity<MenuItem>()
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<MenuItem>()
                .Property(m => m.Description)
                .IsRequired()
                .HasMaxLength(500);

            modelBuilder.Entity<MenuItem>()
                .Property(m => m.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<MenuItem>()
                .Property(m => m.Category)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(50);

            modelBuilder.Entity<MenuItem>()
                .Property(m => m.AvailabilityStatus)
                .IsRequired();

            modelBuilder.Entity<MenuItem>()
                .Property(m => m.LastUpdated)
                .IsRequired()
                .HasColumnType("datetime2(0)");


            // Seed data for MenuItem
            modelBuilder.Entity<MenuItem>().HasData
                (
                    // Appetizer
                    new MenuItem
                    {
                        MenuItemId = 1,
                        Name = "Bruschetta",
                        Description = "Grilled bread topped with diced tomatoes, garlic, and basil.",
                        Price = 6.99m,
                        Category = Category.Appetizer,
                        AvailabilityStatus = true,
                        LastUpdated = DateTime.UtcNow
                    },
                    new MenuItem
                    {
                        MenuItemId = 2,
                        Name = "Stuffed Mushrooms",
                        Description = "Mushrooms stuffed with garlic, herbs, and cream cheese.",
                        Price = 7.99m,
                        Category = Category.Appetizer,
                        AvailabilityStatus = true,
                        LastUpdated = DateTime.UtcNow
                    },

                    // Starter
                    new MenuItem
                    {
                        MenuItemId = 3,
                        Name = "Garlic Bread",
                        Description = "Toasted bread slices with garlic butter.",
                        Price = 4.99m,
                        Category = Category.Starter,
                        AvailabilityStatus = true,
                        LastUpdated = DateTime.UtcNow
                    },
                    new MenuItem
                    {
                        MenuItemId = 4,
                        Name = "Tomato Basil Soup",
                        Description = "Creamy tomato soup with fresh basil.",
                        Price = 5.99m,
                        Category = Category.Starter,
                        AvailabilityStatus = true,
                        LastUpdated = DateTime.UtcNow
                    },

                    // Main Course
                    new MenuItem
                    {
                        MenuItemId = 5,
                        Name = "Grilled Salmon",
                        Description = "Grilled salmon fillet served with lemon butter sauce.",
                        Price = 15.99m,
                        Category = Category.MainCourse,
                        AvailabilityStatus = true,
                        LastUpdated = DateTime.UtcNow
                    },
                    new MenuItem
                    {
                        MenuItemId = 6,
                        Name = "Beef Steak",
                        Description = "Juicy grilled beef steak with a side of vegetables.",
                        Price = 19.99m,
                        Category = Category.MainCourse,
                        AvailabilityStatus = true,
                        LastUpdated = DateTime.UtcNow
                    },

                    // Dessert
                    new MenuItem
                    {
                        MenuItemId = 7,
                        Name = "Chocolate Lava Cake",
                        Description = "Warm chocolate cake with a gooey molten center.",
                        Price = 6.99m,
                        Category = Category.Dessert,
                        AvailabilityStatus = true,
                        LastUpdated = DateTime.UtcNow
                    },
                    new MenuItem
                    {
                        MenuItemId = 8,
                        Name = "Tiramisu",
                        Description = "Classic Italian dessert with layers of mascarpone and espresso-soaked ladyfingers.",
                        Price = 5.99m,
                        Category = Category.Dessert,
                        AvailabilityStatus = true,
                        LastUpdated = DateTime.UtcNow
                    },

                    // Beverage
                    new MenuItem
                    {
                        MenuItemId = 9,
                        Name = "Espresso",
                        Description = "Strong and rich espresso coffee.",
                        Price = 2.99m,
                        Category = Category.Beverage,
                        AvailabilityStatus = true,
                        LastUpdated = DateTime.UtcNow
                    },
                    new MenuItem
                    {
                        MenuItemId = 10,
                        Name = "Lemonade",
                        Description = "Refreshing homemade lemonade.",
                        Price = 3.99m,
                        Category = Category.Beverage,
                        AvailabilityStatus = true,
                        LastUpdated = DateTime.UtcNow
                    },

                    // Side Dish
                    new MenuItem
                    {
                        MenuItemId = 11,
                        Name = "French Fries",
                        Description = "Crispy golden fries with a side of ketchup.",
                        Price = 3.99m,
                        Category = Category.SideDish,
                        AvailabilityStatus = true,
                        LastUpdated = DateTime.UtcNow
                    },
                    new MenuItem
                    {
                        MenuItemId = 12,
                        Name = "Mashed Potatoes",
                        Description = "Creamy mashed potatoes with butter and herbs.",
                        Price = 4.99m,
                        Category = Category.SideDish,
                        AvailabilityStatus = true,
                        LastUpdated = DateTime.UtcNow
                    },

                    // Soup
                    new MenuItem
                    {
                        MenuItemId = 13,
                        Name = "Minestrone Soup",
                        Description = "Hearty Italian soup with vegetables and pasta.",
                        Price = 5.99m,
                        Category = Category.Soup,
                        AvailabilityStatus = true,
                        LastUpdated = DateTime.UtcNow
                    },
                    new MenuItem
                    {
                        MenuItemId = 14,
                        Name = "Chicken Noodle Soup",
                        Description = "Classic chicken soup with noodles and vegetables.",
                        Price = 5.99m,
                        Category = Category.Soup,
                        AvailabilityStatus = true,
                        LastUpdated = DateTime.UtcNow
                    },

                    // Salad
                    new MenuItem
                    {
                        MenuItemId = 15,
                        Name = "Greek Salad",
                        Description = "Salad with tomatoes, cucumbers, olives, and feta cheese.",
                        Price = 6.99m,
                        Category = Category.Salad,
                        AvailabilityStatus = true,
                        LastUpdated = DateTime.UtcNow
                    },
                    new MenuItem
                    {
                        MenuItemId = 16,
                        Name = "Caprese Salad",
                        Description = "Fresh tomatoes, mozzarella, and basil with balsamic glaze.",
                        Price = 7.99m,
                        Category = Category.Salad,
                        AvailabilityStatus = true,
                        LastUpdated = DateTime.UtcNow
                    },

                    // Special
                    new MenuItem
                    {
                        MenuItemId = 17,
                        Name = "Lobster Tail",
                        Description = "Succulent lobster tail served with drawn butter.",
                        Price = 29.99m,
                        Category = Category.Special,
                        AvailabilityStatus = true,
                        LastUpdated = DateTime.UtcNow
                    },
                    new MenuItem
                    {
                        MenuItemId = 18,
                        Name = "Truffle Risotto",
                        Description = "Creamy risotto with truffle oil and parmesan.",
                        Price = 24.99m,
                        Category = Category.Special,
                        AvailabilityStatus = true,
                        LastUpdated = DateTime.UtcNow
                    },

                    // Kids
                    new MenuItem
                    {
                        MenuItemId = 19,
                        Name = "Chicken Nuggets",
                        Description = "Crispy chicken nuggets served with fries.",
                        Price = 5.99m,
                        Category = Category.Kids,
                        AvailabilityStatus = true,
                        LastUpdated = DateTime.UtcNow
                    },
                    new MenuItem
                    {
                        MenuItemId = 20,
                        Name = "Mac and Cheese",
                        Description = "Creamy macaroni and cheese.",
                        Price = 4.99m,
                        Category = Category.Kids,
                        AvailabilityStatus = true,
                        LastUpdated = DateTime.UtcNow
                    },

                    // Vegetarian
                    new MenuItem
                    {
                        MenuItemId = 21,
                        Name = "Vegetable Stir-Fry",
                        Description = "Mixed vegetables stir-fried with soy sauce and served over rice.",
                        Price = 9.99m,
                        Category = Category.Vegetarian,
                        AvailabilityStatus = true,
                        LastUpdated = DateTime.UtcNow
                    },
                    new MenuItem
                    {
                        MenuItemId = 22,
                        Name = "Vegetarian Lasagna",
                        Description = "Lasagna layered with spinach, ricotta, and marinara sauce.",
                        Price = 11.99m,
                        Category = Category.Vegetarian,
                        AvailabilityStatus = true,
                        LastUpdated = DateTime.UtcNow
                    }
                );



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
                .HasMany(o => o.SpecialOpeningHours)
                .WithOne(s => s.OpeningHours)
                .HasForeignKey(s => s.OpeningHoursId);


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


            // SpecialOpeningHours
            modelBuilder.Entity<SpecialOpeningHours>()
                .HasKey(s => s.SpecialOpeningHoursId);

            modelBuilder.Entity<SpecialOpeningHours>()
                .Property(s => s.Date)
                .IsRequired();

            modelBuilder.Entity<SpecialOpeningHours>()
                .Property(s => s.OpenTime)
                .HasColumnType("time(0)");

            modelBuilder.Entity<SpecialOpeningHours>()
                .Property(s => s.CloseTime)
                .HasColumnType("time(0)");

            modelBuilder.Entity<SpecialOpeningHours>()
                .Property(s => s.IsClosed)
                .IsRequired();


            // Reservation
            modelBuilder.Entity<Reservation>()
                .HasKey(r => r.ReservationId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Customer)
                .WithMany(c => c.Reservations)
                .HasForeignKey(r => r.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.TimeSlot)
                .WithOne(ts => ts.Reservation)
                .HasForeignKey<Reservation>(r => r.TimeSlotId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reservation>()
                .Property(r => r.ReservationDate)
                .IsRequired()
                .HasColumnType("datetime2");

            modelBuilder.Entity<Reservation>()
                .Property(r => r.NumberOfGuests)
                .IsRequired()
                .HasDefaultValue(1);

            modelBuilder.Entity<Reservation>()
                .Property(r => r.SpecialRequests)
                .HasMaxLength(300);

            modelBuilder.Entity<Reservation>()
                .HasMany(r => r.Tables)
                .WithMany(t => t.Reservations)
                .UsingEntity<Dictionary<string, object>>(
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


            // Seed data for Tables
            modelBuilder.Entity<Table>().HasData
            (
                new Table
                {
                    TableId = 1,
                    TableNumber = 1,
                    SeatingCapacity = 4,
                    Location = "Window"
                },
                new Table
                {
                    TableId = 2,
                    TableNumber = 2,
                    SeatingCapacity = 2,
                    Location = "Patio"
                },
                new Table
                {
                    TableId = 3,
                    TableNumber = 3,
                    SeatingCapacity = 6,
                    Location = "Center"
                },
                new Table
                {
                    TableId = 4,
                    TableNumber = 4,
                    SeatingCapacity = 4,
                    Location = "Corner"
                },
                new Table
                {
                    TableId = 5,
                    TableNumber = 5,
                    SeatingCapacity = 4,
                    Location = "Center"
                },
                new Table
                {
                    TableId = 6,
                    TableNumber = 6,
                    SeatingCapacity = 2,
                    Location = "Window"
                },
                new Table
                {
                    TableId = 7,
                    TableNumber = 7,
                    SeatingCapacity = 8,
                    Location = "Private Room"
                },
                new Table
                {
                    TableId = 8,
                    TableNumber = 8,
                    SeatingCapacity = 6,
                    Location = "Patio"
                },
                new Table
                {
                    TableId = 9,
                    TableNumber = 9,
                    SeatingCapacity = 4,
                    Location = "Corner"
                },
                new Table
                {
                    TableId = 10,
                    TableNumber = 10,
                    SeatingCapacity = 4,
                    Location = "Window"
                },
                new Table
                {
                    TableId = 11,
                    TableNumber = 11,
                    SeatingCapacity = 2,
                    Location = "Bar"
                },
                new Table
                {
                    TableId = 12,
                    TableNumber = 12,
                    SeatingCapacity = 6,
                    Location = "Center"
                },
                new Table
                {
                    TableId = 13,
                    TableNumber = 13,
                    SeatingCapacity = 8,
                    Location = "Private Room"
                },
                new Table
                {
                    TableId = 14,
                    TableNumber = 14,
                    SeatingCapacity = 2,
                    Location = "Patio"
                },
                new Table
                {
                    TableId = 15,
                    TableNumber = 15,
                    SeatingCapacity = 4,
                    Location = "Window"
                }
            );



            // TimeSlot
            modelBuilder.Entity<TimeSlot>()
                .HasKey(ts => ts.TimeSlotId);

            modelBuilder.Entity<TimeSlot>()
                .Property(ts => ts.StartTime)
                .IsRequired();

            modelBuilder.Entity<TimeSlot>()
                .Property(ts => ts.EndTime)
                .IsRequired();

            modelBuilder.Entity<TimeSlot>()
                .HasOne(ts => ts.OpeningHours)
                .WithMany(o => o.TimeSlots)
                .HasForeignKey(ts => ts.OpeningHoursId);

            modelBuilder.Entity<TimeSlot>()
                .HasOne(ts => ts.Table)
                .WithMany(t => t.TimeSlots)
                .HasForeignKey(ts => ts.TableId);

            modelBuilder.Entity<TimeSlot>()
                .HasOne(ts => ts.Reservation)
                .WithOne(r => r.TimeSlot)
                .HasForeignKey<Reservation>(r => r.TimeSlotId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}