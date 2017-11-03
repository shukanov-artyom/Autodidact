using System;
using Microsoft.EntityFrameworkCore;

namespace Api.DataModel
{
    public class ApiDatabaseContext : DbContext
    {
        public ApiDatabaseContext(
            DbContextOptions<ApiDatabaseContext> databaseOptions)
            : base(databaseOptions)
        {
        }

        public DbSet<ChannelUserEntity> ChannelUsers { get; set; }

        public DbSet<ConfirmationCodeEntity> ConfirmationCodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure ChannelUserEntity
            modelBuilder.Entity<ChannelUserEntity>()
                .ToTable("ChannelUsers")
                .HasKey(pk => pk.Id);

            // Configure ConfirmationCodeEntity
            modelBuilder.Entity<ConfirmationCodeEntity>()
                .ToTable("ConfirmationCodes")
                .HasKey(pk => new { pk.UserId, pk.ChannelUserId });

            // Configure DocumentEntity
            modelBuilder.Entity<DocumentEntity>()
                .ToTable("Documents")
                .HasIndex(un => un.Link).IsUnique();
            modelBuilder.Entity<DocumentEntity>()
                .HasOne<ChannelUserEntity>()
                .WithMany()
                .HasForeignKey(d => d.ChannelUserId);
            modelBuilder.Entity<ChannelUserEntity>()
                .HasAlternateKey(k => new { k.ChannelType, k.ChannelUserId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
