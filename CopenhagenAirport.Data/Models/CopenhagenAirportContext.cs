using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CopenhagenAirport.Data.Models
{
    public partial class CopenhagenAirportContext : DbContext
    {
        public CopenhagenAirportContext()
        {
        }

        public CopenhagenAirportContext(DbContextOptions<CopenhagenAirportContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Airline> Airlines { get; set; } = null!;
        public virtual DbSet<Airport> Airports { get; set; } = null!;
        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Gate> Gates { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=localhost; Port=5432; Database=CopenhagenAirport; User Id=postgres; Password=Postgres123!;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airline>(entity =>
            {
                entity.ToTable("Airline");

                entity.Property(e => e.AirlineId)
                    .ValueGeneratedNever()
                    .HasColumnName("airline_id");

                entity.Property(e => e.AirlineName)
                    .HasMaxLength(90)
                    .HasColumnName("airline_name");
            });

            modelBuilder.Entity<Airport>(entity =>
            {
                entity.ToTable("Airport");

                entity.Property(e => e.AirportId)
                    .ValueGeneratedNever()
                    .HasColumnName("airport_id");

                entity.Property(e => e.AirportName)
                    .HasMaxLength(60)
                    .HasColumnName("airport_name");

                entity.Property(e => e.City)
                    .HasMaxLength(60)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(30)
                    .HasColumnName("country");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.BookingId)
                    .ValueGeneratedNever()
                    .HasColumnName("booking_id");

                entity.Property(e => e.AirlineId).HasColumnName("airline_id");

                entity.Property(e => e.AirportId).HasColumnName("airport_id");

                entity.Property(e => e.FlightNumber)
                    .HasMaxLength(10)
                    .HasColumnName("flight_number");

                entity.Property(e => e.GateId).HasColumnName("gate_id");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.Time)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("time");

                entity.HasOne(d => d.Airline)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.AirlineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Airline");

                entity.HasOne(d => d.Airport)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.AirportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Airport");

                entity.HasOne(d => d.Gate)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.GateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gate");
            });

            modelBuilder.Entity<Gate>(entity =>
            {
                entity.ToTable("Gate");

                entity.Property(e => e.GateId)
                    .ValueGeneratedNever()
                    .HasColumnName("gate_id");

                entity.Property(e => e.GateName)
                    .HasMaxLength(30)
                    .HasColumnName("gate_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
