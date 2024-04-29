using juego.Contexto;
using juego.Modelos;
using juego.Services.TuProyecto.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace juego.Controladores
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuentesEnergiaController : ControllerBase
    {
        private readonly IFuenteEnergiaService _fuenteEnergiaService;

        public FuentesEnergiaController(IFuenteEnergiaService fuenteEnergiaService)
        {
            _fuenteEnergiaService = fuenteEnergiaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FuenteEnergia>>> GetFuentesEnergia()
        {
            return Ok(await _fuenteEnergiaService.ObtenerFuentesEnergia());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FuenteEnergia>> GetFuenteEnergia(int id)
        {
            var fuenteEnergia = await _fuenteEnergiaService.ObtenerFuenteEnergiaById(id);
            if (fuenteEnergia == null)
            {
                return NotFound();
            }
            return Ok(fuenteEnergia);
        }

        [HttpPost]
        public async Task<ActionResult<FuenteEnergia>> PostFuenteEnergia(FuenteEnergia fuenteEnergia)
        {
            var nuevaFuenteEnergia = await _fuenteEnergiaService.CrearFuenteEnergia(fuenteEnergia);
            return CreatedAtAction("GetFuenteEnergia", new { id = nuevaFuenteEnergia.Id }, nuevaFuenteEnergia);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuenteEnergia(int id, FuenteEnergia fuenteEnergia)
        {
            if (id != fuenteEnergia.Id)
            {
                return BadRequest();
            }

            await _fuenteEnergiaService.ActualizarFuenteEnergia(fuenteEnergia);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuenteEnergia(int id)
        {
            await _fuenteEnergiaService.EliminarFuenteEnergia(id);
            return NoContent();
        }
    }
}
