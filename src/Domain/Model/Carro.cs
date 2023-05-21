using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Carro
    {
        public Carro(string nomeCarro, int tempoAbastecimento)
        {
            NomeCarro = nomeCarro;
            TempoAbastecimento = tempoAbastecimento;
        }
        public int Id { get; set; }
        public string NomeCarro { get; set; }
        public int TempoAbastecimento { get; set; }

    }
}
