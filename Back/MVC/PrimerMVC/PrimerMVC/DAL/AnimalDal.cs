using PrimerMVC.Models;
using System.Data.SqlClient;

namespace PrimerMVC.DAL
{
    public class AnimalDal
    {
        private string connectionString = "Data Source=85.208.21.117,54321;Initial Catalog=DaniAnimales;User ID=sa;Password=Sql#123456789;TrustServerCertificate=True;";
        [Obsolete]
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
    }
}
