using Microsoft.Data.SqlClient;

namespace Proyecto_GYM
{
    public class Conexion
    {
        private static readonly string connectionString =
            "Server=DESKTOP-AR0O5IR\\SQLEXPRESS;Database=GimnasioDB;Integrated Security=True;TrustServerCertificate=True;";

        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conexion = new SqlConnection(connectionString);
            conexion.Open();
            return conexion;
        }
    }
}