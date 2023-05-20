using Domain.Model;


namespace Domain.Interface.Repository
{
    public interface IProdutoRepository
    {
        Produto Adicionar(Produto produto);
        bool Apagar(int id);
        Produto Atualizar(Produto produto);
        List<Produto> BuscarTodos();
        Produto BuscarPorId(int id);

    }
}
