namespace juego.Modelos
{
    public class PlantaJugador
    {
        public int Id { get; set; }
        public int JugadorId { get; set; }
        public Jugador Jugador { get; set; }
        public int PlantaId { get; set; }
        public Planta Planta { get; set; }
    }
}
