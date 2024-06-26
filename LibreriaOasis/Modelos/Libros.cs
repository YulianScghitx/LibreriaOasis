namespace LibreriaOasis.Modelos
{
    public class Libros
    {
        public int id { get; set; }
        public int categoria { get; set; }
        public int stock { get; set; }
        public int sucursal { get; set; }
        public string nombre { get; set; } = null!;
        public decimal precio { get; set; }
        public DateTime fecha { get; set; }
        public string? imagen { get; set; }
    }
}
