using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHA_B4_ConsoleApp
{
    internal class AppDbContext : DbContext
    {
        private readonly string _db;

        public AppDbContext(string connectionString)
        {
            _db = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_db);
        }

        public DbSet<ProductEntity> Medicines { get; set; }
    }
}
