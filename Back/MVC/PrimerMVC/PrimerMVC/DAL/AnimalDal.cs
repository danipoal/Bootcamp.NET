using Microsoft.Data.SqlClient;
using PrimerMVC.Models;

namespace PrimerMVC.DAL
{
    public class AnimalDal
    {
        private string connectionString = "Data Source=85.208.21.117,54321;Initial Catalog=DaniAnimales;User ID=sa;Password=Sql#123456789;TrustServerCertificate=True;";
        public List<Animal> GetAll()
        {
            List<Animal> animales = new List<Animal>();
            TipoAnimalDal tipoaAnimalDal = new TipoAnimalDal();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Animal";
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Animal animal = new Animal()
                    {
                        IdAnimal = Convert.ToInt32(reader["IdAnimal"]),
                        NombreAnimal = reader["NombreAnimal"].ToString(),
                        Raza = reader["Raza"]?.ToString(),
                        RITipoAnimal = Convert.ToInt32(reader["RIdTipoAnimal"].ToString()),
                        FechaNacimiento = reader["FechaNacimiento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaNacimiento"]),
                        TipoAnimal = tipoaAnimalDal.GetById(Convert.ToInt32(reader["RIdTipoAnimal"])),
                    };
                    animales.Add(animal);

                }
                return new List<Animal>(animales);
            }

        }
        public Animal GetById(int id)
        {
            TipoAnimalDal tipoAnimalDal = new TipoAnimalDal();  // Asumiendo que TipoAnimalDal tiene un método GetById
            Animal animal = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Animal WHERE IdAnimal = @id";
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                cmd.Parameters.AddWithValue("@id", id);  // Usar parámetros para prevenir SQL Injection
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())  // Solo esperamos una fila, no necesitamos while
                {
                    animal = new Animal()
                    {
                        IdAnimal = Convert.ToInt32(reader["IdAnimal"]),
                        NombreAnimal = reader["NombreAnimal"].ToString(),
                        Raza = reader["Raza"]?.ToString(),
                        RITipoAnimal = Convert.ToInt32(reader["RIdTipoAnimal"]),
                        FechaNacimiento = reader["FechaNacimiento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaNacimiento"]),
                        TipoAnimal = tipoAnimalDal.GetById(Convert.ToInt32(reader["RIdTipoAnimal"]))
                    };
                }
            }
            return animal;  // Devolver el animal encontrado o null si no se encontró ninguno
        }
        public int Create(Animal newAnimal)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string Query = @"INSERT INTO Animal(NombreAnimal, Raza, RIdTipoAnimal, FechaNacimiento) 
                                VALUES (@NombreAnimal, @Raza, @RIdTipoAnimal,@FechaNacimiento);
                                SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(Query, conn);

                cmd.Parameters.AddWithValue("@NombreAnimal", newAnimal.NombreAnimal);
                cmd.Parameters.AddWithValue("@Raza", newAnimal.Raza);
                cmd.Parameters.AddWithValue("@RIdTipoAnimal", newAnimal.RITipoAnimal); //Acordarse que aqui se pasa un id a la tabla

                cmd.Parameters.AddWithValue("@FechaNacimiento", newAnimal.FechaNacimiento ?? (object)DBNull.Value);   //Como puede ser null hay que manejar la posibilidad
                
                conn.Open();
                object result = cmd.ExecuteScalar();

                return (result != null) ? Convert.ToInt32(result) : 0;  // Maneja el caso donde SCOPE_IDENTITY() puede retornar null
            }

        }
        public bool DeleteById(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sqlQuery = "DELETE FROM Animal WHERE IdAnimal = @id";
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                cmd.Parameters.AddWithValue("@id", id);  // Protección contra la inyección SQL

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();  // Ejecuta la consulta y retorna el número de filas afectadas

                return rowsAffected > 0;  // Retorna true si alguna fila fue eliminada
            }
        }
        public bool UpdateById(Animal newAnimal)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string Query = @"UPDATE Animal SET NombreAnimal = @NombreAnimal,
                                                   Raza = @Raza,
                                                   RIdTipoAnimal = @RIdTipoAnimal,
                                                   FechaNacimiento = @FechaNacimiento
                                    WHERE IdAnimal = @id";
                
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@id", newAnimal.IdAnimal);

                cmd.Parameters.AddWithValue("@NombreAnimal", newAnimal.NombreAnimal);
                cmd.Parameters.AddWithValue("@Raza", newAnimal.Raza);
                cmd.Parameters.AddWithValue("@RIdTipoAnimal", newAnimal.RITipoAnimal);
                cmd.Parameters.AddWithValue("@FechaNacimiento", newAnimal.FechaNacimiento);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery(); 
                
                return rowsAffected > 0;
            }
        }

    }
}
