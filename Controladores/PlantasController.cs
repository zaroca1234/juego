using juego.Contexto;
using juego.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace juego.Controladores
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantasController : ControllerBase
    {
        private readonly VideoJuegoContext _context;

        public PlantasController(VideoJuegoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Planta>>> GetPlantas()
        {
            return await _context.Plantas.Include(p => p.FuenteEnergia).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Planta>> GetPlanta(int id)
        {
            var planta = await _context.Plantas.Include(p => p.FuenteEnergia).FirstOrDefaultAsync(p => p.Id == id);

            if (planta == null)
            {
                return NotFound();
            }

            return planta;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlanta(int id, Planta planta)
        {
            if (id != planta.Id)
            {
                return BadRequest();
            }

            _context.Entry(planta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Planta>> PostPlanta(Planta planta)
        {
            _context.Plantas.Add(planta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlanta", new { id = planta.Id }, planta);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlanta(int id)
        {
            var planta = await _context.Plantas.FindAsync(id);
            if (planta == null)
            {
                return NotFound();
            }

            _context.Plantas.Remove(planta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlantaExists(int id)
        {
            return _context.Plantas.Any(e => e.Id == id);
        }
    }
}
