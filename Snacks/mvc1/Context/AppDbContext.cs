using mvc1.Models;
using Microsoft.EntityFrameworkCore;


namespace mvc1.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Snack> Snacks { get; set; }
        public DbSet<CartItens> CartItens { get; set; }
    }
}