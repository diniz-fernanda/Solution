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

        public Carro Adicionar(Carro carro)
        {
            _bancoContext.Carros.Add(carro);
            _bancoContext.SaveChanges();
            return carro;
        }
        public Carro BuscarPorId(int id)
        {
            return _bancoContext.Carros.SingleOrDefault(x => x.Id == id);
        }

        List<Carro> IPostoDeGasolinaRepository.BuscarCarros()
        {
            return _bancoContext.Carros.ToList();
        }

    }
}
