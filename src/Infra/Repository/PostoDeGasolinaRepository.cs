using Domain.Interface.Repository;
using Domain.Model;
using Infra.Context;

namespace Infra.Repository
{
    public class PostoDeGasolinaRepository : IPostoDeGasolinaRepository
    {
        private readonly BancoContext _bancoContext;
        public PostoDeGasolinaRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        List<PostoDeGasolina> IPostoDeGasolinaRepository.BuscarCarros()
        {
            return _bancoContext.PostoDeGasolina.ToList();
        }
    }
}
