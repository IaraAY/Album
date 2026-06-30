using Microsoft.Data.SqlClient;
using Dapper;
namespace TP4_Album.Models;

public class BD(){
    private string _connectionString = @"Server=localhost; DataBase=Album;Integrated Security=True;TrustServerCertificate=True;";
}