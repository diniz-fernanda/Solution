using Domain.Interface.Repository;
using Domain.Interface.Service;
using Domain.Model;

namespace Aplication
{
    public class APPService : IAppService
    {
        private readonly ICarroRepository _repository;
        public APPService(ICarroRepository repository) 
        { 
            _repository = repository; 
        }
        private async Task AbastecerCarro(Carro carro)
        {
            PostoDeGasolina posto = new PostoDeGasolina { QuantidadeBombas = 3 };
            var filaDeEspera = new List<Carro>();

            lock (posto)
            {
                while (filaDeEspera.Count >= posto.QuantidadeBombas)
                {
                    Task.Delay(1000); // Aguarda 1 segundo antes de verificar novamente
                }

                filaDeEspera.Add(carro);
            }

            // Aguarda até que o carro seja o próximo na fila e uma bomba esteja disponível
            while (filaDeEspera[0] != carro || posto.BombaDisponivel)
            {
                await Task.Delay(1000); 
            }

            posto.BombaDisponivel = false;

            // Simular o tempo de abastecimento
            await Task.Delay(carro.TempoAbastecimento * 1000);

            posto.BombaDisponivel = true;
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

                _repository.Adicionar(carro);
                
            }

            return carrosAbastecidos;
        }
    }
}