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
        public Produto()
        {
        }
        public int Id { get; private set; }
        public string Nome { get; set; }
        public decimal Valor { get;  set; }
        public StatusVenda Vendido { get; set; }

        public void Update(string nome, decimal valor, StatusVenda vendido)
        {
            Nome = nome;
            Valor = valor;
            Vendido = vendido;
        }
    }
}
