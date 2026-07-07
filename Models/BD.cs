using Microsoft.Data.SqlClient;
using Dapper;
namespace TP4_Album.Models;

public class BD
{
    private string _connectionString = @"Server=localhost; DataBase=Album;Integrated Security=True;TrustServerCertificate=True";

    public List<Figuritas> AbrirSobre()
    {
        List<Figuuritas> figuritas = new List<Figuritas>();
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            string query = "SELECT TOP 5 * FROM Figuritas ORDER BY NEWID()";
            Figuritas = connection.Query<Figuritas>(query).ToList();
        }
        return figuritas;
    }

    public void GuardarSobre(int idUsuario, List<int> figuritas)
    {
        string query = "INSERT INTO Figuritas (Foto, NombreJugador, idSeleccion, Posicion, NumCamiseta) VALUES (@Foto, @NombreJugador, @idSeleccion, @Posicion, @NumCamiseta)";
        bool resultado;
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            resultado = connection.Execute(query, new {Foto = f.Foto, NombreJugador = f.NombreJugador, idSeleccion = s.idSeleccion, Posicion = f.Posicion, NumCamiseta = f.NumCamiseta});
        }
        return resultado;
    }

    public List<Figurita> ObtenerAlbum(int idUsuario)
    {
        List<FiguritaAlbum> figuritas;
        string query = "SELECT (Foto, NombreJugador, idSeleccion, Posicion, NumCamiseta) FROM Figuritas VALUES (@Foto, @NombreJugador, @idSeleccion, @Posicion, @NumCamiseta)";;
        int resultado;
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            resultado = connection.Execute(query, new {Foto = f.Foto, NombreJugador = f.NombreJugador, idSeleccion = s.idSeleccion, Posicion = f.Posicion, NumCamiseta = f.NumCamiseta});
        }
        return resultado;
    }

    public List<FiguritaXUsuario> ObtenerRepetidas(int idUsuario)
    {
        
    }
}