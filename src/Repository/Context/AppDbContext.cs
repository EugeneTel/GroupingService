using System;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repository.Context
{
    public class AppDbContext : DbContext
    {
        internal DbSet<Models.User> Users { get; set; }
        internal DbSet<Models.Group> Groups { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Group>()
                .HasMany(g => g.Users)
                .WithOne();

            //TODO set relationships between tables
            modelBuilder.Entity<User>().HasData(new User {
                Id = 1,
                Name = "Administrator",
                SkillIndex = 0.5f,
                RemoteIndex = 50,
                ConnectedAt = DateTime.Now
            });

            base.OnModelCreating(modelBuilder);            
        }
    }
}