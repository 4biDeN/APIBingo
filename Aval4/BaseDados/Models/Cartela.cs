namespace Aval4.BaseDados.Models
{
    public class Cartela
    {
        public int Id { get; set; }
        public List<int> Numeros { get; set; } = new List<int>();
        public string Jogador { get; set; }
        public bool Vencedora { get; set; } = false;
    }
}
