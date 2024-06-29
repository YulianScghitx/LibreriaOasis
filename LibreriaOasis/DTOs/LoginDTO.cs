namespace LibreriaOasis.DTOs
{
    public class LoginDTO
    {
        public string correo { get; set; } = null!;
        public string contrasena { get; set; } = null!;
        public int tipo_usuario { get; set; }
    }
}
