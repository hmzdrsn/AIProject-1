using AIProject.Domain.Abstraction;
using AIProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject.Infrastructure
{
    public class ApplicationContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=AIProjectDb;TrustServerCertificate=true;integrated security=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            /*

                  var entries = ChangeTracker.Entries<Entity>();
                 foreach (var entry in entries)
                 {
                     if (entry.State == EntityState.Added)
                     {
                         entry.Property(p => p.Id)
                             .CurrentValue = Guid.NewGuid().ToString();
                     }

                 }
             */
        // modelBuilder.Entity<Entity>()
        //.Property(e => e.Id)
        //.HasDefaultValue(Guid.NewGuid().ToString());

        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<Entity>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property(p => p.Id)
                        .CurrentValue = Guid.NewGuid().ToString();
                }

                if (entry.State == EntityState.Added)
                {
                    entry.Property(p => p.CreatedAt)
                        .CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property(p => p.UpdatedAt)
                        .CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Chat> Chats { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<Prompt> Prompts{ get; set; }
        public DbSet<EnglishDegree> EnglishDegrees { get; set; }


        

    }
}
