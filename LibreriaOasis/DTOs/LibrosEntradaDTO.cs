namespace LibreriaOasis.DTOs
{
    public class LibrosEntradaDTO
    {
        public int categoria { get; set; }
        public int stock { get; set; }
        public int sucursal { get; set; }
        public string nombre { get; set; } = null!;
        public decimal precio { get; set; }
        public DateTime fecha { get; set; }
        public IFormFile? imagen { get; set; }
    }
}
