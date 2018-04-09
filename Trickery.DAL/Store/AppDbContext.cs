using System;
using Microsoft.EntityFrameworkCore;
using Trickery.DAL.Model;

namespace Trickery.DAL.Store
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected AppDbContext()
        {
        }

        public DbSet<GoogleUserMap> GoogleUserMaps { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            InitUsertables(modelBuilder);
        }

        private void InitUsertables(ModelBuilder builder)
        {
            builder.Entity<User>(b =>
            {
                b.HasKey(x => x.Id);
            });

            builder.Entity<GoogleUserMap>(b =>
            {
                b.HasKey(x => x.Id);
                b.HasOne(x => x.User)
                    .WithMany(x => x.GoogleUserMaps)
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
