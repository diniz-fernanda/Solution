using Domain.Model.Enums;

namespace Domain.Model
{
    public class Produto
    {
        public Produto(string nome, decimal valor, StatusVenda vendido)
        {
            Nome = nome;
            Valor = valor;
            Vendido = vendido;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public decimal Valor { get; private set; }
        public StatusVenda Vendido { get; private set; }

        public void Update(string nome, decimal valor, StatusVenda vendido)
        {
            Nome = nome;
            Valor = valor;
            Vendido = vendido;
        }
    }
}
