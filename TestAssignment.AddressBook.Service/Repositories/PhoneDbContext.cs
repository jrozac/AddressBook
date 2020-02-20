using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;
using System;
using TestAssignment.AddressBook.Models;

namespace TestAssignment.AddressBook.Repositories
{

    /// <summary>
    /// Database context for phone
    /// </summary>
    public class PhoneDbContext : DbContext
    {

        private readonly PhoneDbContextCfg _config;

        public PhoneDbContext(IOptions<PhoneDbContextCfg> config)
        {
            _config = config.Value;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // setup database provider
                switch (_config.DatabaseType)
                {
                    case PhoneDbContextCfg.EnumDatabaseType.InMemory:
                        optionsBuilder.UseInMemoryDatabase(_config.ConnectionString);
                        break;
                    case PhoneDbContextCfg.EnumDatabaseType.Sql:
                        optionsBuilder.UseSqlServer(_config.ConnectionString);
                        break;
                    default:
                        throw new Exception($"Database type {_config.DatabaseType} is not supported.");
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // make phone number unique
            builder.Entity<Contact>().HasIndex(u => u.PhoneNumber).IsUnique();
        }

        /// <summary>
        /// Contacts table
        /// </summary>
        public DbSet<Contact> Contacts { get; set; }

    }
}
