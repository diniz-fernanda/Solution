using Domain.Model;

namespace Domain.Interface.Repository
{
    public interface IPostoDeGasolinaRepository
    {
        List<Carro> BuscarCarros();
        Carro Adicionar (Carro carro);
        Carro BuscarPorId(int id);

    }
}
