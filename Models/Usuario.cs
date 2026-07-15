namespace TP4_Album.Models;

public class Usuario
{
    public int IdUsuario { get; set; }
    public string NombreUsuario { get; set; }
    public string Email { get; set; }
    public List<Figuritas> figuritas;
}