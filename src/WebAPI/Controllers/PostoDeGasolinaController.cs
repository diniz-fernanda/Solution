using Domain.Interface.Repository;
using Domain.Interface.Service;
using Domain.Model;
using Infra.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostoDeGasolinaController : ControllerBase
    {
        private readonly IPostoDeGasolinaRepository _postoDeGasolinaRepository;
        private readonly IPostoDeGasolinaAppService _postoDeGasolinaAppService;
        public PostoDeGasolinaController(IPostoDeGasolinaRepository postoDeGasolinaRepository, IPostoDeGasolinaAppService postoDeGasolinaAppService)
        {
            _postoDeGasolinaRepository = postoDeGasolinaRepository;
            _postoDeGasolinaAppService = postoDeGasolinaAppService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var carros = _postoDeGasolinaRepository.BuscarCarros();

            return Ok(carros);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var carro = _postoDeGasolinaRepository.BuscarPorId(id);

            if (carro == null)
            {
                return NotFound();
            }

            return Ok(carro);
        }

        [HttpPost]
        public async Task<IActionResult> PostoDeGasolina(Carro[] carros)
        {
            try
            {
                var carrosAbastecidos = await _postoDeGasolinaAppService.PostoDeGasolina(carros);
                Carro primeiroCarroAbastecido = carrosAbastecidos.SingleOrDefault();
                return CreatedAtAction(
                    nameof(GetById),
                    new { id = primeiroCarroAbastecido.Id},
                    carrosAbastecidos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
