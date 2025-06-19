using Microsoft.EntityFrameworkCore;
using Track2Grow.API.Models.Entities;

namespace Track2Grow.API.Data
{
    public class Track2GrowDbContext : DbContext
    {
        public Track2GrowDbContext(DbContextOptions<Track2GrowDbContext> options)
            : base(options)
        {
        }

        // DbSets for each entity
        public DbSet<User> Users { get; set; }
        public DbSet<CompanyGoal> CompanyGoals { get; set; }
        public DbSet<Commitment> Commitments { get; set; }
        public DbSet<ProgressUpdate> ProgressUpdates { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User relationships
            modelBuilder.Entity<User>()
                .HasMany(u => u.AssignedCommitments)
                .WithOne(c => c.AssignedToUser)
                .HasForeignKey(c => c.AssignedTo)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(u => u.CreatedCommitments)
                .WithOne(c => c.AssignedByUser)
                .HasForeignKey(c => c.AssignedBy)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Comments)
                .WithOne(c => c.CreatedByUser)
                .HasForeignKey(c => c.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            // Goal creator
            modelBuilder.Entity<CompanyGoal>()
                .HasOne(g => g.Creator)
                .WithMany()
                .HasForeignKey(g => g.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            // Commitment relationships
            modelBuilder.Entity<Commitment>()
                .HasOne(c => c.Goal)
                .WithMany(g => g.Commitments)
                .HasForeignKey(c => c.GoalId)
                .OnDelete(DeleteBehavior.Cascade);

            // Progress update relationship
            modelBuilder.Entity<ProgressUpdate>()
                .HasOne(p => p.Commitment)
                .WithMany(c => c.ProgressUpdates)
                .HasForeignKey(p => p.CommitmentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
