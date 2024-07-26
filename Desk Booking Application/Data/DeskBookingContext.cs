using Desk_Booking_Application.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

public class DeskBookingContext : IdentityDbContext<User>
{
    public DbSet<Building> Buildings { get; set; }
    public DbSet<Floor> Floors { get; set; }
    public DbSet<Desk> Desks { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DeskBookingContext(DbContextOptions<DeskBookingContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Floor>()
            .HasOne(f => f.Building)
            .WithMany(b => b.Floors)
            .HasForeignKey(f => f.BuildingId);

        modelBuilder.Entity<Desk>()
            .HasOne(d => d.Floor)
            .WithMany(f => f.Desks)
            .HasForeignKey(d => d.FloorId);

        modelBuilder.Entity<Booking>()
            .HasOne(b => b.User)
            .WithMany(u => u.Bookings)
            .HasForeignKey(b => b.UserId);

        modelBuilder.Entity<Booking>()
            .HasOne(b => b.Desk)
            .WithMany()
            .HasForeignKey(b => b.DeskId);
    }
}
