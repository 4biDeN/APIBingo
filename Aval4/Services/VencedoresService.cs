using Aval4.BaseDados;
using Aval4.BaseDados.Models;
using Microsoft.EntityFrameworkCore;

namespace Aval4.Services
{
    public class VencedoresService
    {
        private readonly BingoContext _context;

        public VencedoresService()
        {
            var optionsBuilder = new DbContextOptionsBuilder<BingoContext>();
            optionsBuilder.UseInMemoryDatabase("BingoDatabase");

            _context = new BingoContext(optionsBuilder.Options);
        }

        public List<Cartela> RevelarVencedores()
        {
            var numerosSorteados = _context.NumerosSorteados.Select(n => n.Numero).ToList();

            var vencedores = _context.Cartelas
                .AsEnumerable()
                .Where(c => c.Numeros.All(n => numerosSorteados.Contains(n)))
                .ToList();

            foreach (var cartela in vencedores)
            {
                cartela.Vencedora = true;
            }

            _context.SaveChanges();
            return vencedores;
        }
    }
}
