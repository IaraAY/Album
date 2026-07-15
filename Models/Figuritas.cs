namespace TP4_Album.Models;

public class Figuritas
{
    public int IdFigurita { get; set; }
    public string Foto { get; set; }
    public string NombreJugador {get; set; }
    public int idSeleccion {get; set;}
    public string Posicion {get; set;}
    public int NumCamiseta {get; set;}

    public int CantidadFU(int idFigurita, int idUsuario){
        BD bd = new BD();
        return bd.Cantidad(idFigurita, idUsuario);
    }
}