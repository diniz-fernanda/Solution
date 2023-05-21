using Domain.Interface.Service;
using Domain.Model;

namespace Aplication
{
    public class PostoDeGasolinaAPPService : IPostoDeGasolinaAppService
    {
        public void AdicionarCarroNaFila(Carro carro, PostoDeGasolina posto)
        {
            posto.FilaDeEspera.Add(carro);
        }
        List<Carro> IPostoDeGasolinaAppService.AbastecerCarros(PostoDeGasolina posto)
        {
            for (int i = 0; i < posto.QuantidadeBombas && posto.FilaDeEspera.Count > 0; i++)
            {
                Carro proximoCarro = posto.FilaDeEspera[0];
                posto.FilaDeEspera.RemoveAt(0);

                posto.CarrosAbastecidos.Add(proximoCarro);
            }

            return posto.CarrosAbastecidos;
        }
    }
}