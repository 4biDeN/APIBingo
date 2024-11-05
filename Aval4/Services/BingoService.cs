using Aval4.BaseDados.Models;
using Aval4.BaseDados;
using Microsoft.EntityFrameworkCore;

namespace Aval4.Services
{
    public class BingoService
    {
        private readonly BingoContext _context;

        public BingoService(BingoContext context)
        {
            _context = context;
        }
        public Cartela ImprimirCartela(string jogador)
        {
            var cartela = new Cartela
            {
                Jogador = jogador,
                Numeros = GerarNumerosAleatorios()
            };
            _context.Cartelas.Add(cartela);
            _context.SaveChanges();
            return cartela;
        }
        public NumeroSorteado SortearNumero()
        {
            var numerosSorteados = _context.NumerosSorteados.Select(n => n.Numero).ToList();
            Random rand = new Random();
            int numero;
            do
            {
                numero = rand.Next(1, 81); 
            } while (numerosSorteados.Contains(numero)); 

            var numeroSorteado = new NumeroSorteado { Numero = numero};
            _context.NumerosSorteados.Add(numeroSorteado);
            _context.SaveChanges();

            return numeroSorteado;
        }
        private List<int> GerarNumerosAleatorios()
        {
            Random rand = new Random();
            return Enumerable.Range(1, 81).OrderBy(x => rand.Next()).Take(15).ToList();
        }
    }
}
