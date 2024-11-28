using LoginMVC.Models;
using Microsoft.Data.SqlClient;


namespace LoginMVC.DAL
{
    public class UsuarioDAL
    {
        public string connectionString = @"Data Source=85.208.21.117,54321;
                                           Initial Catalog=DaniLogin;
                                           User ID=sa;Password=Sql#123456789;
                                           TrustServerCertificate=True;";

        public Usuario getUsuarioLogin(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Usuario WHERE UserName = @UserName AND Pwd = @Pwd";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@UserName", username);
                cmd.Parameters.AddWithValue("@Pwd", password);
                connection.Open();
                // Si quieres que se lea algo hay que hacer un executeReader en vez de un executeNonQuery
                using (var reader = cmd.ExecuteReader())
                {   
                    // Si hay contenido para leer
                    if (reader.Read())
                    {
                        return new Usuario
                        {
                            IdUsuario = (int)reader["IdUsuario"],     // as int si no hubiera devulveria null
                            UserName = (string)reader["UserName"],
                            Pwd = (string)reader["Pwd"],
                            Apellido = (string)reader["Apellido"],
                            Email = reader["Email"] as string,
                            FechaNacimiento = reader["FechaNacimiento"] as DateTime?,
                            Telefono = reader["Telefono"] as string,
                            Direccion = reader["Direccion"] as string,
                            Ciudad = reader["Ciudad"] as string,
                            Estado = reader["Estado"] as string,
                            CodigoPostal = reader["CodigoPostal"] as string,
                            FechaRegistro = reader["FechaRegistro"] as DateTime?,
                            Activo = (bool)reader["Activo"]
                        };
                    }
                    // Si no hay Read, no se ha encontrado nada en el Select asi que return null
                    return null;
                }

            }

        }
    }
}
