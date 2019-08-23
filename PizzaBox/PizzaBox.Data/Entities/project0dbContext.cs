using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaBox.Data.Entities
{
    public partial class project0dbContext : DbContext
    {
        public project0dbContext()
        {
        }

        public project0dbContext(DbContextOptions<project0dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Crust> Crust { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Name> Name { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<Size> Size { get; set; }
        public virtual DbSet<Topping> Topping { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:pizzabox.database.windows.net,1433;Initial Catalog=project0db;Persist Security Info=False;User ID=sqladmin;Password=Password12345;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address", "PizzaStore");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Crust>(entity =>
            {
                entity.ToTable("Crust", "PizzaStore");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("numeric(4, 2)");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location", "PizzaStore");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Location)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AddressId");
            });

            modelBuilder.Entity<Name>(entity =>
            {
                entity.ToTable("Name", "PizzaStore");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order", "PizzaStore");

                entity.Property(e => e.OrderTime).HasColumnType("datetime");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LocationId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserId");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.ToTable("Pizza", "PizzaStore");

                entity.Property(e => e.Price).HasColumnType("numeric(5, 2)");

                entity.HasOne(d => d.Crust)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.CrustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CrustId");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderId");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.SizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SizeId");

                entity.HasOne(d => d.ToppingId1Navigation)
                    .WithMany(p => p.PizzaToppingId1Navigation)
                    .HasForeignKey(d => d.ToppingId1)
                    .HasConstraintName("FK_ToppingId1");

                entity.HasOne(d => d.ToppingId2Navigation)
                    .WithMany(p => p.PizzaToppingId2Navigation)
                    .HasForeignKey(d => d.ToppingId2)
                    .HasConstraintName("FK_ToppingId2");

                entity.HasOne(d => d.ToppingId3Navigation)
                    .WithMany(p => p.PizzaToppingId3Navigation)
                    .HasForeignKey(d => d.ToppingId3)
                    .HasConstraintName("FK_ToppingId3");

                entity.HasOne(d => d.ToppingId4Navigation)
                    .WithMany(p => p.PizzaToppingId4Navigation)
                    .HasForeignKey(d => d.ToppingId4)
                    .HasConstraintName("FK_ToppingId4");

                entity.HasOne(d => d.ToppingId5Navigation)
                    .WithMany(p => p.PizzaToppingId5Navigation)
                    .HasForeignKey(d => d.ToppingId5)
                    .HasConstraintName("FK_ToppingId5");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.ToTable("Size", "PizzaStore");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("numeric(4, 2)");
            });

            modelBuilder.Entity<Topping>(entity =>
            {
                entity.ToTable("Topping", "PizzaStore");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("numeric(4, 2)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "PizzaStore");

                entity.HasOne(d => d.Name)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.NameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NameId");
            });
        }
    }
}
