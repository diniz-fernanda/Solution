using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Model
{
    public class Carro
    {
        public Carro(string nomeCarro, int tempoAbastecimento)
        {
            NomeCarro = nomeCarro;
            TempoAbastecimento = tempoAbastecimento;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NomeCarro { get; set; }
        public int TempoAbastecimento { get; set; }
        public void Update(string nomeCarro, int tempoAbastecimento)
        {
            NomeCarro = nomeCarro;
            TempoAbastecimento = tempoAbastecimento;
        }
    }
}
