using Microsoft.EntityFrameworkCore;
using webAPI_membro.Models;

namespace webAPI_membro.DataContext
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        public DbSet<MemboModel> Membros { get; set; }
    }
}
