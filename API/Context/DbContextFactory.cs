
using API.Config;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;


namespace API.Context
{
    public class DbContextFactory : IDbContextFactory, IDisposable
    {
        /// <summary>
        /// Create Db context with connection string
        /// </summary>
        /// <param name="settings"></param>
        public DbContextFactory(IOptions<DbContextSettings> settings) 
        {
            var options = new DbContextOptionsBuilder<TPVDbContext>().UseNpgsql(settings.Value.DbConnectionString).EnableSensitiveDataLogging().Options;
                //,
                //npgsqlOptionsAction: s =>
                //{
                //  s.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorCodesToAdd: null);
                //}).Options;
            DbContext = new TPVDbContext(options);
            DbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        /// <summary>
        /// Call Dispose to release DbContext
        /// </summary>
        ~DbContextFactory()
        {
            Dispose();
        }

        public TPVDbContext DbContext { get; private set; }
        /// <summary>
        /// Release DB context
        /// </summary>
        public void Dispose()
        {
            DbContext?.Dispose();
        }
    }
}
