using Microsoft.Data.SqlClient;
using Dapper;
namespace TP4_Album.Models;

public class BD
{
    private string _connectionString;
    public BD()
    {
        _connectionString = @"Server=localhost; DataBase=Album;Integrated Security=True;TrustServerCertificate=True";
    }
    public int Cantidad(int idFigurita, int idUsuario){
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = @"SELECT Cantidad FROM FiguritaUsuario WHERE IdFigurita = @pidFigurita AND IdUsuario = @pidUsuario";
            int respuesta = connection.QueryFirstOrDefault<int>(query, new {pidFigurita = idFigurita, pidUsuario = idUsuario});
            if(respuesta == null)
                respuesta = 0;
            return respuesta;
        }
    }
    public List<Figuritas> AbrirSobre()
    {
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = @"SELECT TOP 5 * FROM Figuritas ORDER BY NEWID()";
            return connection.Query<Figuritas>(query).ToList();
        }
    }

    public void GuardarSobre(int idUsuario, List<int> idsFiguritas)
    {
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            foreach(int id in idsFiguritas)
            {
                string existe = @"SELECT COUNT(*) FROM FiguritaUsuario WHERE IdUsuario=@idUsuario AND IdFigurita=@id";
                int cantidad = connection.ExecuteScalar<int>(existe, new { idUsuario, id });
                if(cantidad==0)
                {
                    string insert = @"INSERT INTO FiguritaUsuario (IdUsuario, IdFigurita, Cantidad) VALUES (@idUsuario,@id,1)";
                    connection.Execute(insert,new {idUsuario,id});
                }
                else
                {
                    string update = @"UPDATE FiguritaUsuario SET Cantidad=Cantidad+1 WHERE IdUsuario=@idUsuario AND IdFigurita=@id";
                    connection.Execute(update,new {idUsuario,id});
                }
            }
        }
    }

    public List<Figuritas> ObtenerAlbum(int idUsuario)
    {
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query=@"SELECT f.*, ISNULL(fu.Cantidad,0) Cantidad FROM Figuritas f LEFT JOIN FiguritaUsuario fu ON f.IdFigurita=fu.IdFigurita AND fu.IdUsuario=@idUsuario ORDER BY f.IdFigurita";
            return connection.Query<Figuritas>(query,new{idUsuario}).ToList();
        }
    }

    public List<Figuritas> ObtenerMiAlbum(int idUsuario)
    {
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query=@"SELECT * FROM FiguritaUsuario fu;";
            return connection.Query<Figuritas>(query,new{idUsuario}).ToList();
        }
    }
}