namespace juego.Modelos
{
    public class Planta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public int CapacidadProduccion { get; set; }
        public int FuenteEnergiaId { get; set; }
        public FuenteEnergia FuenteEnergia { get; set; }
        public ICollection<PlantaJugador> PlantasJugador { get; set; }

        public Planta()
        {
            PlantasJugador = new List<PlantaJugador>();
        }
    }
}

