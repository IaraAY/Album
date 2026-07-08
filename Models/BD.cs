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

    public void GuardarSobre(int idUsuario, List<Figuritas> figuritas)
    {
        string query1 = "INSERT INTO FiguritaUsuario (IdFigurita, IdUsuario, Cantidad) VALUES (@figurita.IdFigurita, @idUsuario)";
        string query2 = "";
        bool resultado;
        int cantidad;
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            foreach(Figurita figurita in figuritas){
                if(figurita.Cantidad = 0){
                    connection.Execute(query, new {IdFigurita = figurita.IdFigurita, IdUsuario = idUsuario, Cantidad = cantidad});
                }
                else
                    cantidad += 1;
                
            }
        }
        return resultado;
    }

    public List<Figurita> ObtenerAlbum()
    {
        List<Figurita> Album;
        string query = "SELECT (Foto, NombreJugador, idSeleccion, Posicion, NumCamiseta) FROM Figuritas";
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            Album = connection.Query<Figuritas>(query).ToList();
        }
        return resultado;
    }

    public List<FiguritaUsuario> ObtenerMiAlbum(int idUsuario)
    {
        List<FiguritaAlbum> figuritas;
        string query = "SELECT (fu.IdFigurita, f.NombreJugador, f.Foto, f.Posicion, fu.Cantidad) FROM FiguritaUsuario fu INNER JOIN Figuritas f ON (f.IdFigurita = fu.IdFigurita) WHERE (fu.IdUsuario = @idUsuario)";
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            Album = connection.Query<Figuritas>(query).ToList();
        }
        return resultado;
    }

    public List<FiguritaUsuario> ObtenerRepetidas(int idUsuario)
    {
        
    }
}