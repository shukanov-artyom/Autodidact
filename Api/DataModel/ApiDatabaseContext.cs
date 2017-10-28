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
            modelBuilder.Entity<ChannelUserEntity>()
                .ToTable("ChannelUsers")
                .HasKey(pk => pk.Id);
            modelBuilder.Entity<ConfirmationCodeEntity>()
                .ToTable("ConfirmationCodes")
                .HasKey(pk => new { pk.UserId, pk.ChannelUserId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
