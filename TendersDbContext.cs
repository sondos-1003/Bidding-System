using EntitiesTest.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using System.Reflection.Emit;

namespace EntitiesTest
{
    public class TendersDbContext : DbContext
    {
        public TendersDbContext(DbContextOptions<TendersDbContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Tender> Tenders { get; set; }
        public DbSet<TenderDocument> TenderDocuments { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<BidDocument> BidDocuments { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User ↔ Role: Many-to-Many (through UserRole)
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Users)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(ur => ur.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            // User → Tender: One-to-Many (CreatedBy)
            modelBuilder.Entity<Tender>()
     .HasOne(t => t.CreatedBy)
     .WithMany() // Assuming no navigation property on User
     .HasForeignKey(t => t.CreatedById)
     .OnDelete(DeleteBehavior.SetNull);
            // Assuming soft delete or nullable FK

            // User → Bidder: One-to-One
            modelBuilder.Entity<Bidder>()
                .HasOne(b => b.User)
                .WithOne(u => u.BidderProfile)
                .HasForeignKey<Bidder>(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Organization → Tender: One-to-Many
            modelBuilder.Entity<Tender>()
                .HasOne(t => t.Organization)
                .WithMany(o => o.Tenders)
                .HasForeignKey(t => t.OrganizationId)
                .OnDelete(DeleteBehavior.NoAction);

            // Tender ↔ Category: Many-to-Many (through TenderCategory)
            modelBuilder.Entity<TenderCategory>()
                .HasKey(tc => new { tc.TenderId, tc.CategoryId });

            modelBuilder.Entity<TenderCategory>()
                .HasOne(tc => tc.Tender)
                .WithMany(t => t.Categories)
                .HasForeignKey(tc => tc.TenderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TenderCategory>()
                .HasOne(tc => tc.Category)
                .WithMany(c => c.Tenders)
                .HasForeignKey(tc => tc.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            // Tender → TenderDocument: One-to-Many
            modelBuilder.Entity<Tender>()
                .HasMany(t => t.Documents)
                .WithOne(d => d.Tender)
                .HasForeignKey(d => d.TenderId)
                .OnDelete(DeleteBehavior.NoAction);

            // Tender → EligibilityCriterion: One-to-Many
            modelBuilder.Entity<Tender>()
                .HasMany(t => t.EligibilityCriteria)
                .WithOne(ec => ec.Tender)
                .HasForeignKey(ec => ec.TenderId)
                .OnDelete(DeleteBehavior.Cascade);

            // Tender → EvaluationCriterion: One-to-Many
            modelBuilder.Entity<Tender>()
                .HasMany(t => t.EvaluationCriteria)
                .WithOne(ec => ec.Tender)
                .HasForeignKey(ec => ec.TenderId)
                .OnDelete(DeleteBehavior.NoAction);

            // Tender → Bid: One-to-Many
            modelBuilder.Entity<Tender>()
                .HasMany(t => t.Bids)
                .WithOne(b => b.Tender)
                .HasForeignKey(b => b.TenderId)
                .OnDelete(DeleteBehavior.NoAction);

            // Bidder → Bid: One-to-Many
            modelBuilder.Entity<Bidder>()
                .HasMany(b => b.Bids)
                .WithOne(bid => bid.Bidder)
                .HasForeignKey(bid => bid.BidderId)
                .OnDelete(DeleteBehavior.Cascade);

            // Bid → BidDocument: One-to-Many
            modelBuilder.Entity<Bid>()
                .HasMany(b => b.Documents)
                .WithOne(d => d.Bid)
                .HasForeignKey(d => d.BidId)
                .OnDelete(DeleteBehavior.Cascade);

            // Bid → BidFinancialDetail: One-to-Many
            modelBuilder.Entity<Bid>()
                .HasMany(b => b.FinancialDetails)
                .WithOne(fd => fd.Bid)
                .HasForeignKey(fd => fd.BidId)
                .OnDelete(DeleteBehavior.Cascade);

            // Bid → TechnicalProposal: One-to-One
            modelBuilder.Entity<Bid>()
                .HasOne(b => b.TechnicalProposal)
                .WithOne(tp => tp.Bid)
                .HasForeignKey<TechnicalProposal>(tp => tp.BidId)
                .OnDelete(DeleteBehavior.Cascade);

            // Bidder → PastExperience: One-to-Many
            modelBuilder.Entity<Bidder>()
                .HasMany(b => b.PastExperiences)
                .WithOne(pe => pe.Bidder)
                .HasForeignKey(pe => pe.BidderId)
                .OnDelete(DeleteBehavior.Cascade);

            // Bidder → FinancialStatement: One-to-Many
            modelBuilder.Entity<Bidder>()
                .HasMany(b => b.FinancialStatements)
                .WithOne(fs => fs.Bidder)
                .HasForeignKey(fs => fs.BidderId)
                .OnDelete(DeleteBehavior.Cascade);

            // Tender → Evaluation: One-to-Many
            modelBuilder.Entity<Tender>()
                .HasMany(t => t.Evaluations)
                .WithOne(e => e.Tender)
                .HasForeignKey(e => e.TenderId)
                .OnDelete(DeleteBehavior.NoAction);

            // Bid → Evaluation: One-to-Many
            modelBuilder.Entity<Bid>()
                .HasMany(b => b.Evaluations)
                .WithOne(e => e.Bid)
                .HasForeignKey(e => e.BidId)
                .OnDelete(DeleteBehavior.Cascade);

            // User → Evaluation: One-to-Many (Evaluator)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Evaluations)
                .WithOne(e => e.Evaluator)
                .HasForeignKey(e => e.EvaluatorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Evaluation → CriterionScore: One-to-Many
            modelBuilder.Entity<Evaluation>()
                .HasMany(e => e.Scores)
                .WithOne(cs => cs.Evaluation)
                .HasForeignKey(cs => cs.EvaluationId)
                .OnDelete(DeleteBehavior.Cascade);

            // User → Notification: One-to-Many
            modelBuilder.Entity<User>()
                .HasMany(u => u.Notifications)
                .WithOne(n => n.User)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }

}
