using Domain.Model;

namespace Domain.Interface.Repository
{
    public interface ICarroRepository
    {
        List<Carro> BuscarCarros();
        Carro Adicionar (Carro carro);
        Carro BuscarPorId(int id);
        bool Apagar(int id);
        Carro Atualizar(Carro carro);
    }
}
