using Domain.Interface.Repository;
using Domain.Model;
using Infra.Context;

namespace Infra.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private BancoContext _bancoContext;
        public ProdutoRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public Produto Adicionar(Produto produto)
        {
            _bancoContext.Produtos.Add(produto);
            _bancoContext.SaveChanges();
            return produto;
        }

        public bool Apagar(int id)
        {
            Produto produtoDB = BuscarPorId(id);

            _bancoContext.Produtos.Remove(produtoDB);
            _bancoContext.SaveChanges();
            return true;
        }

        public Produto Atualizar(Produto produto)
        {
            _bancoContext.Produtos.Update(produto);
            _bancoContext.SaveChanges();
            return produto;
        }

        public Produto BuscarPorId(int id)
        {
            return _bancoContext.Produtos.SingleOrDefault(x => x.Id == id);
        }

        public List<Produto> BuscarTodos()
        {
            return _bancoContext.Produtos.ToList();
        }
    }
}
