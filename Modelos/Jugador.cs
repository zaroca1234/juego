namespace juego.Modelos
{
    public class Jugador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int EnergiaAcumulada { get; set; }
        public string Correo { get; set; }

        public string Constrasena { get; set; }
        public ICollection<PlantaJugador> PlantasJugador { get; set; }

        public Jugador()
        {
            PlantasJugador = new List<PlantaJugador>();
        }
    }
}
