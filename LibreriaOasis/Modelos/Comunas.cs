using System.ComponentModel.DataAnnotations;

namespace LibreriaOasis.Modelos
{
    public class Comunas
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; } = null!;
        public int region { get; set; }
    }
}
