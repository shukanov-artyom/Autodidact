using System;
using Microsoft.EntityFrameworkCore;
using Api.Options;
using Microsoft.Extensions.Options;

namespace Api.DataModel
{
    public class ApiDatabaseContext : DbContext
    {
        private readonly PersistencyOptions databaseOptions;
        private readonly string connectionString;

        public ApiDatabaseContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public ApiDatabaseContext(IOptions<PersistencyOptions> databaseOptions)
        {
            this.databaseOptions = databaseOptions.Value;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string selectedConnectionString;
            //if (databaseOptions != null)
            //{
            //    selectedConnectionString = databaseOptions.WarnerDatabase;
            //}
            //else
            //{
            //    selectedConnectionString = connectionString;
            //}
            //optionsBuilder.UseSqlServer(selectedConnectionString);
            //base.OnConfiguring(optionsBuilder);
        }
    }
}
