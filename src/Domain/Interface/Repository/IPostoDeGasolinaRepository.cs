using Domain.Model;

namespace Domain.Interface.Repository
{
    public interface IPostoDeGasolinaRepository
    {
        List<PostoDeGasolina> BuscarCarros();
    }
}
