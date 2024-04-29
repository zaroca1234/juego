using juego.Contexto;
using juego.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace juego.Controladores
{
    [Route("api/[controller]")]
    [ApiController]
    public class JugadoresController : ControllerBase
    {
        private readonly VideoJuegoContext _context;

        public JugadoresController(VideoJuegoContext context)
        {
            _context = context;
        }

        // GET: api/Jugadores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jugador>>> GetJugadores()
        {
            return await _context.Jugadores.Include(j => j.PlantasJugador).ThenInclude(pj => pj.Planta).ToListAsync();
        }

        // GET: api/Jugadores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Jugador>> GetJugador(int id)
        {
            var jugador = await _context.Jugadores.Include(j => j.PlantasJugador).ThenInclude(pj => pj.Planta).FirstOrDefaultAsync(j => j.Id == id);

            if (jugador == null)
            {
                return NotFound();
            }

            return jugador;
        }

        // PUT: api/Jugadores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJugador(int id, Jugador jugador)
        {
            if (id != jugador.Id)
            {
                return BadRequest();
            }

            _context.Entry(jugador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JugadorExists(id))
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

        // POST: api/Jugadores
        [HttpPost]
        public async Task<ActionResult<Jugador>> PostJugador(Jugador jugador)
        {
            _context.Jugadores.Add(jugador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJugador", new { id = jugador.Id }, jugador);
        }

        // DELETE: api/Jugadores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJugador(int id)
        {
            var jugador = await _context.Jugadores.FindAsync(id);
            if (jugador == null)
            {
                return NotFound();
            }

            _context.Jugadores.Remove(jugador);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JugadorExists(int id)
        {
            return _context.Jugadores.Any(e => e.Id == id);
        }
    }
}
