using Domain.Interface.Repository;
using Domain.Interface.Service;
using Domain.Model;
using Infra.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/carro")]
    [ApiController]
    public class CarroController : ControllerBase
    {
        private readonly ICarroRepository _carroRepository;
        private readonly IPostoDeGasolinaAppService _postoDeGasolinaAppService;
        public CarroController(ICarroRepository carroRepository, IPostoDeGasolinaAppService postoDeGasolinaAppService)
        {
            _carroRepository = carroRepository;
            _postoDeGasolinaAppService = postoDeGasolinaAppService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var carros = _carroRepository.BuscarCarros();

            return Ok(carros);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var carro = _carroRepository.BuscarPorId(id);

            if (carro == null)
            {
                return NotFound();
            }

            return Ok(carro);
        }

        [HttpPost]
        public async Task<IActionResult> Abastecer(Carro[] carros)
        {
            try
            {
                var carrosAbastecidos = await _postoDeGasolinaAppService.PostoDeGasolina(carros);
                Carro primeiroCarroAbastecido = carrosAbastecidos.FirstOrDefault();
                carrosAbastecidos.OrderBy(x => x.TempoAbastecimento);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = primeiroCarroAbastecido.Id },
                    carrosAbastecidos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Carro Carro)
        {
            var carroExistente = _carroRepository.BuscarPorId(id);

            if (carroExistente == null)
            {
                return NotFound();
            }

            carroExistente.Update(Carro.NomeCarro, Carro.TempoAbastecimento);
            _carroRepository.Atualizar(carroExistente);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Carro = _carroRepository.BuscarPorId(id);

            if (Carro == null)
            {
                return NotFound();
            }

            _carroRepository.Apagar(id);
            return NoContent();
        }

    }
}
