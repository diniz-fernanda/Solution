using Domain.Interface.Repository;
using Domain.Model;
using Infra.Context;

namespace Infra.Repository
{
    public class CarroRepository : ICarroRepository
    {
        private readonly BancoContext _bancoContext;
        public CarroRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public Carro Adicionar(Carro carro)
        {
            try
            {
                carro.Id = 0;
                _bancoContext.Carros.Add(carro);
                _bancoContext.SaveChanges();
                return carro;
            }
            catch (Exception e)
            {
                throw new ("Erro ao adicionar o carro.", e);
            }
            
        }

        List<Carro> ICarroRepository.BuscarCarros()
        {
            return _bancoContext.Carros.ToList();
        }

        public Carro BuscarPorId(int id)
        {
            return _bancoContext.Carros.SingleOrDefault(x => x.Id == id);
        }

        public bool Apagar(int id)
        {
            Carro carroDB = BuscarPorId(id);

            _bancoContext.Carros.Remove(carroDB);
            _bancoContext.SaveChanges();
            return true;
        }

        public Carro Atualizar(Carro carro)
        {
            _bancoContext.Carros.Update(carro);
            _bancoContext.SaveChanges();
            return carro;
        }
    }
}
