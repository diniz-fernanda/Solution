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

        public PostoDeGasolina AdicionarProduto(PostoDeGasolina posto)
        {
            try
            {
                _bancoContext.PostoDeGasolina.Add(posto);
                _bancoContext.SaveChanges();
                return posto;

            }
            catch (Exception e)
            {
                throw new("Erro ao adicionar o posto.", e);

            }
        }

        public bool Apagar(int id)
        {
            PostoDeGasolina postoDB = BuscarPorIdProduto(id);

            _bancoContext.PostoDeGasolina.Remove(postoDB);
            _bancoContext.SaveChanges();
            return true;
        }

        public PostoDeGasolina Atualizar(PostoDeGasolina posto)
        {
            _bancoContext.PostoDeGasolina.Update(posto);
            _bancoContext.SaveChanges();
            return posto;
        }

        public PostoDeGasolina BuscarPorIdProduto(int id)
        {
            return _bancoContext.PostoDeGasolina.SingleOrDefault(x => x.Id == id);

        }

        public List<PostoDeGasolina> BuscarTodos()
        {
            return _bancoContext.PostoDeGasolina.ToList();
        }
    }
}
