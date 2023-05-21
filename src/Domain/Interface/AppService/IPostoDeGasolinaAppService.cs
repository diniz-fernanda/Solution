using Domain.Model;

namespace Domain.Interface.Service
{
    public interface IPostoDeGasolinaAppService
    {
         void AdicionarCarroNaFila(Carro carro, PostoDeGasolina posto);
         List<Carro> AbastecerCarros(PostoDeGasolina posto);
    }
}
