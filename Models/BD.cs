using Microsoft.Data.SqlClient;
using Dapper;
namespace TP4_Album.Models;

public class BD
{
    private string _connectionString = @"Server=localhost; DataBase=Album;Integrated Security=True;TrustServerCertificate=True";

    public List<Usuario> ObtenerFiguritas()
    {
        List<Usuario> Usuario = new List<Usuario>();
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            string query = "SELECT * FROM UsuariosXFiguritas";
            turnos = connection.Query<Usuario>(query).ToList();
        }
        return turnos;
    }

    public int AgregarTurno(Turno t)
    {
        string query = "INSERT INTO Usuario (Email, Nombbre) VALUES (@pEmail, @pNombreUsuario)";
        int resultado;
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            resultado = connection.Execute(query, new {pEmail = t.Email, pNombreUsuario = t.Nombre});
        }
        return resultado;
    }

    public int CambiarEstado(int id, string nuevoEstado)
    {
        string query = "UPDATE Turnos Set Estado = @nuevoEstado WHERE Id = @id";
        int resultado;
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            resultado = connection.Execute(query, new{id, nuevoEstado});
        }
        return resultado;
    }
}