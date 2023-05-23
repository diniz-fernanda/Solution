using Domain.Model;

namespace Domain.Interface.Service
{
    public interface IAppService
    {
        Task <List<Carro>> PostoDeGasolina(Carro[] carros);
    }
}
