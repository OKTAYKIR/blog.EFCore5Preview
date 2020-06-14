using EFCore5Preview1.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace EFCore5Preview1.Context
{
    public class SampleDbContext : DbContext
    {
        public virtual DbSet<User> Users{ get; set; }

        public virtual DbSet<Address> Addresses { get; set; }

        public virtual DbSet<KeylessEntity> KeylessEntities { get; set; }

        public virtual DbSet<Blog> Blogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
            //optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            //optionsBuilder.LogTo(Console.WriteLine, new[] { CoreEventId.ContextInitialized, RelationalEventId.CommandExecuted });
            //optionsBuilder.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Name }, LogLevel.Information);
            //optionsBuilder.LogTo(Console.WriteLine, (id, level) => id == RelationalEventId.CommandExecuting);
            optionsBuilder.UseSqlServer("Server=127.0.0.1;Initial Catalog=master;User=sa;Password=Pass@word;");
            
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity
                    .HasKey(pk => pk.Id);

                entity
                    .Property(p => p.Name)
                    .HasMaxLength(60);

                entity
                    .HasMany(o => o.Addresses)
                    .WithOne(m => m.User)
                    .HasForeignKey(fk => fk.Id);
            });



            modelBuilder.Entity<KeylessEntity>(entity =>
            {
                entity
                    .Property(p => p.Name)
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity
                    .HasKey(pk => pk.Id);

                entity
                    .Property(p => p.Street)
                    .IsRequired()
                    .HasMaxLength(40);

                entity
                    .Property(p => p.City)
                    .IsRequired()
                    .HasMaxLength(40);

                entity
                    .Property(p => p.Zip)
                    .IsRequired()
                    .HasMaxLength(40);

                entity
                    .HasOne(m => m.User)
                    .WithMany(o => o.Addresses)
                    .HasForeignKey(fk => fk.UserId);
            });

            modelBuilder.Entity<Blog>(entity =>
            {
                entity
                  .HasKey(pk => pk.Id);

                entity
                   .Property(p => p.Title)
                   .HasMaxLength(40);
            });

        }
    }
}