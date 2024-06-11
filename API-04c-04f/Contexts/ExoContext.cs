using Exo.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
namespace Exo.WebApi.Contexts
{
    public class ExoContext : DbContext
    {
        public ExoContext()
        {
        }
        public ExoContext(DbContextOptions<ExoContext> options) :
        base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder
        optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Database connection
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;"
                + "Database=ExoApi;Trusted_Connection=True;");
            }
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
