using LoginMVC.Models;
using Microsoft.Data.SqlClient;
using LoginMVC.Tools;


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
                string query = "SELECT * FROM Usuario WHERE UserName = @UserName";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@UserName", username);
                connection.Open();

                // Si quieres que se lea algo hay que hacer un executeReader en vez de un executeNonQuery
                using (var reader = cmd.ExecuteReader())
                {
                    // Si hay contenido para leer
                    if (reader.Read())
                    {
                        var passwordHash = (byte[])reader["PasswordHash"];
                        var passwordSalt = (byte[])reader["PasswordSalt"];

                        if (PasswordHelper.VerifyPasswordHash(password, passwordHash, passwordSalt)) 
                        {
                            // Hay que hacer esta parafernalia para comprobar si es DBNull ya que bd no entiende null
                            return new Usuario
                            {
                                IdUsuario = (int)reader["IdUsuario"], // Este campo probablemente no sea nulo
                                UserName = reader["UserName"] as string, // Correcto uso de 'as' para tipos de referencia
                                PasswordHash = (byte[])reader["PasswordHash"],
                                PasswordSalt = (byte[])reader["PasswordSalt"],
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
                        

                        
                    }
                    connection.Close();
                    // Si no hay Read, no se ha encontrado nada en el Select asi que return null
                    return null;
                }

            }

        }

        public bool CreateUser(Usuario usuario, string password)
        {
            // Generar el Hash y el salt con la contraseña
            PasswordHelper.CreatePasswordHash(password, out byte[] PasswordHash, out byte[] PasswordSalt);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Usuario(UserName, PasswordHash, PasswordSalt)
                                 VALUES (@Username, @PasswordHash, @PasswordSalt)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserName", usuario.UserName);
                cmd.Parameters.AddWithValue("@PasswordHash", PasswordHash);
                cmd.Parameters.AddWithValue("@PasswordSalt", PasswordSalt);

                conn.Open();

                //Devuelve el numero de filas afectadas
                int affectedRows = -1;
                try
                {
                    affectedRows = cmd.ExecuteNonQuery();

                }
                catch (SqlException ex)
                {
                    return false;
                }
                conn.Close();

                if (affectedRows > 0)
                    return true;

                return false;

            }
        }

    }
}
