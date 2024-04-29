namespace juego.Modelos
{
    public class FuenteEnergia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int NivelEnergia { get; set; }
        public bool EsRenovable { get; set; }
        public int RegionId { get; set; }
        public Region Region { get; set; }
        public ICollection<Planta> Plantas { get; set; }
    }
}


