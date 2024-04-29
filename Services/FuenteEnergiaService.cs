namespace juego.Services
{
    using juego.Contexto;
    using juego.Modelos;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    

    namespace TuProyecto.Services
    {
        public class FuenteEnergiaService : IFuenteEnergiaService
        {
            private readonly VideoJuegoContext _context;

            public FuenteEnergiaService(VideoJuegoContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<FuenteEnergia>> ObtenerFuentesEnergia()
            {
                return await _context.FuentesEnergia.Include(fe => fe.Region).ToListAsync();
            }

            public async Task<FuenteEnergia> ObtenerFuenteEnergiaById(int id)
            {
                return await _context.FuentesEnergia.Include(fe => fe.Region).FirstOrDefaultAsync(fe => fe.Id == id);
            }

            public async Task<FuenteEnergia> CrearFuenteEnergia(FuenteEnergia fuenteEnergia)
            {
                _context.FuentesEnergia.Add(fuenteEnergia);
                await _context.SaveChangesAsync();
                return fuenteEnergia;
            }

            public async Task<FuenteEnergia> ActualizarFuenteEnergia(FuenteEnergia fuenteEnergia)
            {
                _context.Entry(fuenteEnergia).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return fuenteEnergia;
            }

            public async Task EliminarFuenteEnergia(int id)
            {
                var fuenteEnergia = await _context.FuentesEnergia.FindAsync(id);
                if (fuenteEnergia != null)
                {
                    _context.FuentesEnergia.Remove(fuenteEnergia);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
