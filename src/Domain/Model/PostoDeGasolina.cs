using Domain.Model.Enums;

namespace Domain.Model
{
    public class PostoDeGasolina
    {
        public int Id { get; private set; }
        public int QuantidadeBombas { get; set; }
        public bool BombaOcupada { get; set; }
        public List<Carro> FilaDeEspera { get; set; }
        public string NomeCombustivel { get; set; }
        public decimal Preco { get; set; }
        public StatusVenda Vendido { get; set; }
        public PostoDeGasolina()
        {
        }
        public PostoDeGasolina(string nomeCombustivel, decimal preco, StatusVenda vendido)
        {
            QuantidadeBombas = 3;
            NomeCombustivel = nomeCombustivel;
            Preco = preco;
            Vendido = vendido;

            FilaDeEspera = new List<Carro>();
        }
    }
}
