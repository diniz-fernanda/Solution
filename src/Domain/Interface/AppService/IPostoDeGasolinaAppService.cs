using Domain.Model;

namespace Domain.Interface.Service
{
    public interface IPostoDeGasolinaAppService
    {
        Task <List<Carro>> PostoDeGasolina(Carro[] carros);
    }
}
