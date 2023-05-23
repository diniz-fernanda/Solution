using Domain.Interface.Repository;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/postoDeGasolina")]
    [ApiController]
    public class PostoDeGasolinaController : ControllerBase
    {
        private readonly IPostoDeGasolinaRepository _postoDeGasolinaRepository;
        public PostoDeGasolinaController(IPostoDeGasolinaRepository postoDeGasolinaRepository)
        {
            _postoDeGasolinaRepository = postoDeGasolinaRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var produtos = _postoDeGasolinaRepository.BuscarTodos();

            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdPosto(int id)
        {
            var carro = _postoDeGasolinaRepository.BuscarPorIdProduto(id);

            if (carro == null)
            {
                return NotFound();
            }

            return Ok(carro);
        }
        [HttpPost]
        public IActionResult Post(PostoDeGasolina postoDeGasolina)
        {
            try
            {
                _postoDeGasolinaRepository.AdicionarProduto(postoDeGasolina);

                return CreatedAtAction(
                    nameof(GetByIdPosto),
                    new { id = postoDeGasolina.Id },
                    postoDeGasolina);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, PostoDeGasolina posto)
        {
            var postoExistente = _postoDeGasolinaRepository.BuscarPorIdProduto(id);

            if (postoExistente == null)
            {
                return NotFound();
            }

            postoExistente.Update(posto.NomeCombustivel, posto.Preco, posto.Vendido);
            _postoDeGasolinaRepository.Atualizar(postoExistente);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var posto = _postoDeGasolinaRepository.BuscarPorIdProduto(id);

            if (posto == null)
            {
                return NotFound();
            }

            _postoDeGasolinaRepository.Apagar(id);
            return NoContent();
        }
    }
}
