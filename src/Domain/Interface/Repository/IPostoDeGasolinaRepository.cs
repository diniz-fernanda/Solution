using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Repository
{
    public interface IPostoDeGasolinaRepository
    {
        PostoDeGasolina AdicionarProduto(PostoDeGasolina posto);
        PostoDeGasolina BuscarPorIdProduto(int id);
        bool Apagar(int id);
        PostoDeGasolina Atualizar(PostoDeGasolina posto);
        List<PostoDeGasolina> BuscarTodos();

    }
}
