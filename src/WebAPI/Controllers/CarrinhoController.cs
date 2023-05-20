using Domain.Interface.Repository;
using Domain.Model;
using Infra.Context;
using Microsoft.AspNetCore.Mvc;

namespace API.WebAPI.Controllers
{
    [Route("api/carrinho")]
    [ApiController]
    public class CarrinhoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public CarrinhoController(IProdutoRepository produtoRepository, BancoContext bancoContext)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            var produtos = _produtoRepository.BuscarTodos();

            return Ok(produtos);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            var produto = _produtoRepository.BuscarPorId(id);

            if(produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }
        
        [HttpPost]
        public IActionResult Post(Produto produto)
        {
            _produtoRepository.Adicionar(produto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = produto.Id },
                produto
                );
        }
        [HttpPut]
        public IActionResult Put(int id, Produto produto)
        {
            var produtoExistente = _produtoRepository.BuscarPorId(id);

            if(produtoExistente == null)
            {
                return NotFound();
            }

            produtoExistente.Update(produto.Nome, produto.Valor, produto.Vendido);
            _produtoRepository.Atualizar(produtoExistente);

            return NoContent();
        }
        [HttpDelete]
        public IActionResult Delete(int id) 
        {
            var produto = _produtoRepository.BuscarPorId(id);

            if(produto == null)
            {
                return NotFound();
            }

            _produtoRepository.Apagar(id);
            return NoContent();
        }
    }
}
