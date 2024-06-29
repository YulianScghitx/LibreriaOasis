using System.ComponentModel.DataAnnotations;

namespace LibreriaOasis.DTOs
{
    public class ComunasDTO
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; } = null!;
        public int region { get; set; }
    }
}
