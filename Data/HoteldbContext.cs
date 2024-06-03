using Microsoft.EntityFrameworkCore;
using Models;
using Models.Utils;

namespace Data;

public partial class HoteldbContext : DbContext
{
    public HoteldbContext()
    {
    }

    public HoteldbContext(DbContextOptions<HoteldbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<Passenger> Passengers { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(GlobalVariables.ConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Hotel__3214EC07B15ABA8D");

            entity.ToTable("Hotel");

            entity.Property(e => e.Location).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Passenger>(entity =>
        {
            entity.HasKey(e => e.PassengerId).HasName("PK__Passenge__88915F901E4FFD6F");

            entity.ToTable("Passenger");

            entity.HasIndex(e => e.DocumentNumber, "UQ__Passenge__68993918AD95AAA4").IsUnique();

            entity.Property(e => e.PassengerId).HasColumnName("PassengerID");
            entity.Property(e => e.ContactName).HasMaxLength(100);
            entity.Property(e => e.ContactPhone).HasMaxLength(15);
            entity.Property(e => e.ContactPhoneNumber).HasMaxLength(15);
            entity.Property(e => e.DocumentNumber).HasMaxLength(50);
            entity.Property(e => e.DocumentType).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LastName).HasMaxLength(100);
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reservat__3214EC071E16343C");

            entity.ToTable("Reservation");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DateEnd).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Room__3214EC074AA4772B");

            entity.ToTable("Room");

            entity.Property(e => e.BaseCost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.Tax).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Type).HasMaxLength(100);

            entity.HasOne(d => d.Hotel).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.HotelId)
                .HasConstraintName("FK__Room__HotelId__3D5E1FD2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
