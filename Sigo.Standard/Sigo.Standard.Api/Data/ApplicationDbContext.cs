using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sigo.Standard.Api.Data.EntityConfiguration;

namespace Sigo.Standard.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Domain.Standard> Standards { get; set; }

        private readonly IConfiguration _configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new StandardConfiguration());
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseMySql(_configuration.GetConnectionString("DefaultConnection"), options =>
            {
                options.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null!);
            });
        }
    }
}