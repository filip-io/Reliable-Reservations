﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reliable_Reservations.Data;

#nullable disable

namespace Reliable_Reservations.Migrations
{
    [DbContext(typeof(ReliableReservationsDbContext))]
    partial class ReliableReservationsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Reliable_Reservations.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Reliable_Reservations.Models.MenuItem", b =>
                {
                    b.Property<int>("MenuItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenuItemId"));

                    b.Property<bool>("AvailabilityStatus")
                        .HasColumnType("bit");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2(0)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("MenuItemId");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("Reliable_Reservations.Models.OpeningHours", b =>
                {
                    b.Property<int>("OpeningHoursId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OpeningHoursId"));

                    b.Property<TimeOnly>("CloseTime")
                        .HasColumnType("time(0)");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<bool>("IsClosed")
                        .HasColumnType("bit");

                    b.Property<TimeOnly>("OpenTime")
                        .HasColumnType("time(0)");

                    b.HasKey("OpeningHoursId");

                    b.ToTable("OpeningHours");

                    b.HasData(
                        new
                        {
                            OpeningHoursId = 1,
                            CloseTime = new TimeOnly(23, 0, 0),
                            DayOfWeek = 0,
                            IsClosed = false,
                            OpenTime = new TimeOnly(10, 0, 0)
                        },
                        new
                        {
                            OpeningHoursId = 2,
                            CloseTime = new TimeOnly(23, 0, 0),
                            DayOfWeek = 1,
                            IsClosed = true,
                            OpenTime = new TimeOnly(10, 0, 0)
                        },
                        new
                        {
                            OpeningHoursId = 3,
                            CloseTime = new TimeOnly(23, 0, 0),
                            DayOfWeek = 2,
                            IsClosed = true,
                            OpenTime = new TimeOnly(10, 0, 0)
                        },
                        new
                        {
                            OpeningHoursId = 4,
                            CloseTime = new TimeOnly(23, 0, 0),
                            DayOfWeek = 3,
                            IsClosed = false,
                            OpenTime = new TimeOnly(10, 0, 0)
                        },
                        new
                        {
                            OpeningHoursId = 5,
                            CloseTime = new TimeOnly(23, 0, 0),
                            DayOfWeek = 4,
                            IsClosed = false,
                            OpenTime = new TimeOnly(10, 0, 0)
                        },
                        new
                        {
                            OpeningHoursId = 6,
                            CloseTime = new TimeOnly(23, 0, 0),
                            DayOfWeek = 5,
                            IsClosed = false,
                            OpenTime = new TimeOnly(10, 0, 0)
                        },
                        new
                        {
                            OpeningHoursId = 7,
                            CloseTime = new TimeOnly(23, 0, 0),
                            DayOfWeek = 6,
                            IsClosed = false,
                            OpenTime = new TimeOnly(10, 0, 0)
                        });
                });

            modelBuilder.Entity("Reliable_Reservations.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfGuests")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2(0)");

                    b.Property<string>("SpecialRequests")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TimeSlotId")
                        .HasColumnType("int");

                    b.HasKey("ReservationId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("TimeSlotId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Reliable_Reservations.Models.SpecialOpeningHours", b =>
                {
                    b.Property<int>("SpecialOpeningHoursId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SpecialOpeningHoursId"));

                    b.Property<TimeOnly?>("CloseTime")
                        .HasColumnType("time(0)");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<bool>("IsClosed")
                        .HasColumnType("bit");

                    b.Property<TimeOnly?>("OpenTime")
                        .HasColumnType("time(0)");

                    b.Property<int>("OpeningHoursId")
                        .HasColumnType("int");

                    b.HasKey("SpecialOpeningHoursId");

                    b.HasIndex("OpeningHoursId");

                    b.ToTable("SpecialOpeningHours");
                });

            modelBuilder.Entity("Reliable_Reservations.Models.TimeSlot", b =>
                {
                    b.Property<int>("TimeSlotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TimeSlotId"));

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2(0)");

                    b.Property<int>("OpeningHoursId")
                        .HasColumnType("int");

                    b.Property<int>("SlotDuration")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2(0)");

                    b.HasKey("TimeSlotId");

                    b.HasIndex("OpeningHoursId");

                    b.ToTable("TimeSlots");
                });

            modelBuilder.Entity("ReservationTables", b =>
                {
                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.Property<int>("TableId")
                        .HasColumnType("int");

                    b.HasKey("ReservationId", "TableId");

                    b.HasIndex("TableId");

                    b.ToTable("ReservationTables");
                });

            modelBuilder.Entity("Table", b =>
                {
                    b.Property<int>("TableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TableId"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SeatingCapacity")
                        .HasColumnType("int");

                    b.Property<int>("TableNumber")
                        .HasColumnType("int");

                    b.HasKey("TableId");

                    b.HasIndex("TableNumber")
                        .IsUnique();

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("Reliable_Reservations.Models.Reservation", b =>
                {
                    b.HasOne("Reliable_Reservations.Models.Customer", "Customer")
                        .WithMany("Reservations")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Reliable_Reservations.Models.TimeSlot", "TimeSlot")
                        .WithMany("Reservations")
                        .HasForeignKey("TimeSlotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("TimeSlot");
                });

            modelBuilder.Entity("Reliable_Reservations.Models.SpecialOpeningHours", b =>
                {
                    b.HasOne("Reliable_Reservations.Models.OpeningHours", "OpeningHours")
                        .WithMany("SpecialOpeningHours")
                        .HasForeignKey("OpeningHoursId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OpeningHours");
                });

            modelBuilder.Entity("Reliable_Reservations.Models.TimeSlot", b =>
                {
                    b.HasOne("Reliable_Reservations.Models.OpeningHours", "OpeningHours")
                        .WithMany("TimeSlots")
                        .HasForeignKey("OpeningHoursId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OpeningHours");
                });

            modelBuilder.Entity("ReservationTables", b =>
                {
                    b.HasOne("Reliable_Reservations.Models.Reservation", null)
                        .WithMany()
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Table", null)
                        .WithMany()
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Reliable_Reservations.Models.Customer", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Reliable_Reservations.Models.OpeningHours", b =>
                {
                    b.Navigation("SpecialOpeningHours");

                    b.Navigation("TimeSlots");
                });

            modelBuilder.Entity("Reliable_Reservations.Models.TimeSlot", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
