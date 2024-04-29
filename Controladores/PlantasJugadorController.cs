using juego.Contexto;
using juego.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace juego.Controladores
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantasJugadorController : ControllerBase
    {
        private readonly VideoJuegoContext _context;

        public PlantasJugadorController(VideoJuegoContext context)
        {
            _context = context;
        }

        // GET: api/PlantasJugador
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlantaJugador>>> GetPlantasJugador()
        {
            return await _context.PlantasJugador.Include(pj => pj.Jugador).Include(pj => pj.Planta).ToListAsync();
        }

        // GET: api/PlantasJugador/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlantaJugador>> GetPlantaJugador(int id)
        {
            var plantaJugador = await _context.PlantasJugador.Include(pj => pj.Jugador).Include(pj => pj.Planta).FirstOrDefaultAsync(pj => pj.Id == id);

            if (plantaJugador == null)
            {
                return NotFound();
            }

            return plantaJugador;
        }

        // PUT: api/PlantasJugador/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlantaJugador(int id, PlantaJugador plantaJugador)
        {
            if (id != plantaJugador.Id)
            {
                return BadRequest();
            }

            _context.Entry(plantaJugador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantaJugadorExists(id))
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

        // POST: api/PlantasJugador
        [HttpPost]
        public async Task<ActionResult<PlantaJugador>> PostPlantaJugador(PlantaJugador plantaJugador)
        {
            _context.PlantasJugador.Add(plantaJugador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlantaJugador", new { id = plantaJugador.Id }, plantaJugador);
        }

        // DELETE: api/PlantasJugador/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlantaJugador(int id)
        {
            var plantaJugador = await _context.PlantasJugador.FindAsync(id);
            if (plantaJugador == null)
            {
                return NotFound();
            }

            _context.PlantasJugador.Remove(plantaJugador);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlantaJugadorExists(int id)
        {
            return _context.PlantasJugador.Any(e => e.Id == id);
        }
    }
}
