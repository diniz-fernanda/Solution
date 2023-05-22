using Domain.Interface.Repository;
using Domain.Interface.Service;
using Domain.Model;

namespace Aplication
{
    public class PostoDeGasolinaAPPService : IPostoDeGasolinaAppService
    {
        private readonly IPostoDeGasolinaRepository _repository;
        public PostoDeGasolinaAPPService(IPostoDeGasolinaRepository repository) 
        { 
            _repository = repository; 
        }
        private async Task AbastecerCarro(Carro carro)
        {
            PostoDeGasolina posto = new PostoDeGasolina { QuantidadeBombas = 3 };
            var filaDeEspera = new List<Carro>();
            filaDeEspera.Add(carro);

            lock (posto)
            {
                while (filaDeEspera.Count >= posto.QuantidadeBombas)
                {
                    Task.Delay(1000); // Aguarda 1 segundo antes de verificar novamente
                }

                filaDeEspera.Add(carro);
            }

            // Aguarda até que o carro seja o próximo na fila e uma bomba esteja disponível
            while (filaDeEspera[0] != carro || posto.BombaOcupada)
            {
                await Task.Delay(1000); // Aguarda 1 segundo antes de verificar novamente
            }

            posto.BombaOcupada = true;

            // Simular o tempo de abastecimento
            await Task.Delay(carro.TempoAbastecimento * 1000);

            posto.BombaOcupada = false;
            filaDeEspera.RemoveAt(0);
        }


        public async Task<List<Carro>> PostoDeGasolina(Carro[] carros)
        {
            PostoDeGasolina posto = new PostoDeGasolina();
            var carrosAbastecidos = new List<Carro>();

            foreach (var carro in carros)
            {
                await AbastecerCarro(carro);
                carrosAbastecidos.Add(carro);

                foreach (var carroAbastecido in carrosAbastecidos)
                {
                    _repository.Adicionar(carroAbastecido);
                }
            }

            return carrosAbastecidos;
        }
        //private async Task<int> ProximaBombaDisponivel(bool[] bombas)
        //{
        //    PostoDeGasolina posto = new PostoDeGasolina();
        //    for (int i = 0; i < posto.QuantidadeBombas && bombas.Length > 0; i++)
        //    {
        //        if (!bombas[i]) // Verifica se a bomba está disponível (false)
        //        {
        //            return i; 
        //        }
        //    }

        //    throw new Exception("Não há bombas disponíveis");
        //}




        //public void AdicionarCarroNaFila(Carro carro)
        //{
        //    PostoDeGasolina posto = new PostoDeGasolina();
        //    if (posto.FilaDeEspera == null)
        //    {
        //        posto.FilaDeEspera.Add(carro);
        //    }

        //    posto.FilaDeEspera.Add(carro);
        //}


        //List<Carro> IPostoDeGasolinaAppService.AbastecerCarro()
        //{
        //    PostoDeGasolina posto = new PostoDeGasolina();
        //    for (int i = 0; i < posto.QuantidadeBombas && posto.FilaDeEspera.Count > 0; i++)
        //    {
        //        Carro proximoCarro = posto.FilaDeEspera[0];
        //        posto.FilaDeEspera.RemoveAt(0);

        //        posto.CarrosAbastecidos.Add(proximoCarro);
        //    }

        //    return posto.CarrosAbastecidos;
        //}
    }
}