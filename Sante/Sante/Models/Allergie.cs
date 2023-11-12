using System.Data.SqlClient;

namespace Sante.Models
{
    public class Allergie
    {
        public Personne personne { get; set; }
        public string nom { get; set; }
        public static List<Allergie> getListByCin(SqlConnection connection, int cin)
        {
            List<Allergie> allergie = new List<Allergie>();
            string query = "SELECT * FROM allergie where cin = @cin";
            Personne olona = Personne.getPersonne(connection, cin);
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@cin", cin);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Allergie indice = new Allergie
                        {
                            personne = olona,
                            nom = reader["nom"].ToString()
                        };
                        allergie.Add(indice);
                    }
                }
            }
            return allergie;
        }

    }
    
}
