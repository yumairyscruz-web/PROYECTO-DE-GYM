using System.Data;
using Microsoft.Data.SqlClient;

namespace Proyecto_GYM
{
    public class Conexion
    {
        // Cadena de conexión hacia tu servidor local y base de datos GimnasioDB
        private static readonly string connectionString = "Server=DESKTOP-AR0O5IR\\SQLEXPRESS; Database=GimnasioDB; Integrated Security=True; TrustServerCertificate=True;";

        // Método para obtener una conexión abierta a SQL Server
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conexion = new SqlConnection(connectionString);
            conexion.Open();
            return conexion;
        }
    }
}