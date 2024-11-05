using Microsoft.EntityFrameworkCore;
using Aval4.BaseDados.Models;

namespace Aval4.BaseDados
{
    public class BingoContext : DbContext
    {
        public BingoContext()
        {
        }
        public BingoContext(DbContextOptions<BingoContext> options) : base(options) { }

        public DbSet<Cartela> Cartelas { get; set; }
        public DbSet<NumeroSorteado> NumerosSorteados { get; set; }
    }

}