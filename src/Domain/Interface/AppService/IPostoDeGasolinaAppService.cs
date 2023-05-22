using Domain.Model;

namespace Domain.Interface.Service
{
    public interface IPostoDeGasolinaAppService
    {
       // Task AbastecerCarro(Carro carro);
        Task <List<Carro>> PostoDeGasolina(Carro[] carros);
    }
}
