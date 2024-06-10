using System.ComponentModel.DataAnnotations;

namespace LibreriaOasis.DTOs
{
    public class UsuariosEntradaDTO
    {
        [Key] public string rut { get; set; } = null!;
        public string primer_nombre { get; set; } = null!;
        public string segundo_nombre { get; set; } = null!;
        public string apellido_paterno { get; set; } = null!;
        public string apellido_materno { get; set; } = null!;
        public string contrasena { get; set; } = null!;
        public string correo { get; set; } = null!;
        public string numero_telefono { get; set; } = null!;
        public int comuna { get; set; }
    }
}
