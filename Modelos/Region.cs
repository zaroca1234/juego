namespace juego.Modelos
{
    public class Region
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public ICollection<FuenteEnergia> FuentesEnergia { get; set; }
    }
}
