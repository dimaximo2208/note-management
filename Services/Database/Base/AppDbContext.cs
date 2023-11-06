using Microsoft.EntityFrameworkCore;
using Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Database.Base
{
    public class AppDbContext : DbContext
    {
        public DbSet<NOTES> NOTES { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=NoteManagement;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
