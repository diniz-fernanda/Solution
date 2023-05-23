using Domain.Model.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
