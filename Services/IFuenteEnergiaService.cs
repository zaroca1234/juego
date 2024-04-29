namespace juego.Services
{
    using juego.Modelos;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    namespace TuProyecto.Services
    {
        public interface IFuenteEnergiaService
        {
            Task<IEnumerable<FuenteEnergia>> ObtenerFuentesEnergia();
            Task<FuenteEnergia> ObtenerFuenteEnergiaById(int id);
            Task<FuenteEnergia> CrearFuenteEnergia(FuenteEnergia fuenteEnergia);
            Task<FuenteEnergia> ActualizarFuenteEnergia(FuenteEnergia fuenteEnergia);
            Task EliminarFuenteEnergia(int id);
        }
    }
}
