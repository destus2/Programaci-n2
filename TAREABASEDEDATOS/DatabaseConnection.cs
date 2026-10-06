using System;
using System.Data.SqlClient;

namespace TAREABASEDEDATOS
{
    public static class DatabaseConnection
    {
        // La cadena de conexión usa |DataDirectory| para apuntar a la carpeta del ejecutable
        public static string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\TaskDB.mdf;Integrated Security=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}