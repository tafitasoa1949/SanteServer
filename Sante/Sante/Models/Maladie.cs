using System.Data.SqlClient;

namespace Sante.Models
{
    public class Maladie
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string symptomes { get; set; }

        public static Maladie GetById(SqlConnection connection,int id)
        {
            Maladie maladie = null;
            string sql = "select * from maladie where id = @id";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        maladie = new Maladie
                        {
                            id = id,
                            nom = reader["nom"].ToString(),
                            symptomes = reader["symptomes"].ToString(),
                        };
                    }
                }
            }
            return maladie;
        }
    }
}
