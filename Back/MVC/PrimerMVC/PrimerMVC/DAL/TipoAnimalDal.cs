using PrimerMVC.Models;
using System.Data.SqlClient;

namespace PrimerMVC.DAL
{
    internal class TipoAnimalDal
    {
        private string connectionString = "Data Source=85.208.21.117,54321;Initial Catalog=DaniAnimales;User ID=sa;Password=Sql#123456789;TrustServerCertificate=True;";

        public TipoAnimal GetById(int id)
        {
            TipoAnimal tipoAnimal = new TipoAnimal();

            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                string Query = "SELECT * FROM TipoAnimal WHERE IdTipoAnimal = @id";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("id", id);
                
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())  // Intenta leer la primera fila
                {
                    int idTipoAnimal = Convert.ToInt32(reader["IdTipoAnimal"]);
                    string? tipoDescripcion = reader["TipoDescripcion"] == DBNull.Value ? null : reader["TipoDescripcion"].ToString();

                    tipoAnimal.IdTipoAnimal = idTipoAnimal;
                    tipoAnimal.TipoDescripcion = tipoDescripcion;
                }

                return tipoAnimal;
            }
        }
    }
}