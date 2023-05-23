using Domain.Model.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Domain.Model
{
    public class PostoDeGasolina
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        public int QuantidadeBombas { get; set; }
        public bool BombaDisponivel { get; set; }
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

        }

        public void Update(string nome, decimal valor, StatusVenda vendido)
        {
            NomeCombustivel = nome;
            Preco = valor;
            Vendido = vendido;
        }

    }
}
