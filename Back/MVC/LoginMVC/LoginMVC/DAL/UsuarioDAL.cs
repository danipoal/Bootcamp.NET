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
                        // Hay que hacer esta parafernalia para comprobar si es DBNull ya que bd no entiende null
                        return new Usuario
                        {
                            IdUsuario = (int)reader["IdUsuario"], // Este campo probablemente no sea nulo
                            UserName = reader["UserName"] as string, // Correcto uso de 'as' para tipos de referencia
                            Pwd = reader["Pwd"] as string,
                            Apellido = reader["Apellido"] as string,
                            Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader["Email"].ToString(),
                            FechaNacimiento = reader.IsDBNull(reader.GetOrdinal("FechaNacimiento")) ? (DateTime?)null : (DateTime)reader["FechaNacimiento"],
                            Telefono = reader.IsDBNull(reader.GetOrdinal("Telefono")) ? null : reader["Telefono"].ToString(),
                            Direccion = reader.IsDBNull(reader.GetOrdinal("Direccion")) ? null : reader["Direccion"].ToString(),
                            Ciudad = reader.IsDBNull(reader.GetOrdinal("Ciudad")) ? null : reader["Ciudad"].ToString(),
                            Estado = reader.IsDBNull(reader.GetOrdinal("Estado")) ? null : reader["Estado"].ToString(),
                            CodigoPostal = reader.IsDBNull(reader.GetOrdinal("CodigoPostal")) ? null : reader["CodigoPostal"].ToString(),
                            FechaRegistro = reader.IsDBNull(reader.GetOrdinal("FechaRegistro")) ? (DateTime?)null : (DateTime)reader["FechaRegistro"],
                            Activo = (bool)reader["Activo"] // Asumiendo que este campo nunca es nulo
                        };

                        
                    }
                    connection.Close();
                    // Si no hay Read, no se ha encontrado nada en el Select asi que return null
                    return null;
                }

            }

        }

        public bool CreateUser(Usuario usuario)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Usuario(UserName, Pwd)
                                 VALUES (@Username, @Pwd)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserName", usuario.UserName);
                cmd.Parameters.AddWithValue("@Pwd", usuario.Pwd);

                conn.Open();

                //Devuelve el numero de filas afectadas
                int affectedRows = cmd.ExecuteNonQuery();
                conn.Close();

                if (affectedRows > 0)
                    return true;

                return false;

            }
        }

    }
}
