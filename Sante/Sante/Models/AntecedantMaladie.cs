using System.Data.SqlClient;

namespace Sante.Models
{
    public class AntecedantMaladie
    {
        public int id { get; set; }
        public int cin { get; set; }
        public Maladie maladie { get; set; }
        public string affection { get; set; }

        public static List<AntecedantMaladie> getListMaladie(SqlConnection connection,int cin)
        {
            List<AntecedantMaladie> list_antecedantMaladice = new List<AntecedantMaladie>();
            string query = "SELECT am.id,am.cin,am.idmaladie,am.affection,m.id as idmaladie,m.nom,m.symptomes " +
                "FROM antecedant_maladie am INNER JOIN maladie m ON am.idmaladie = m.id "+
                "where am.cin=@cin";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@cin", cin);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Maladie new_maladie = new Maladie
                        {
                            id = Convert.ToInt32(reader["idmaladie"]),
                            nom = reader["nom"].ToString(),
                            symptomes = reader["symptomes"].ToString()
                        };
                        AntecedantMaladie antecedantMaladie = new AntecedantMaladie
                        {
                            id = Convert.ToInt32(reader["id"]),
                            cin = cin,
                            maladie = new_maladie,
                            affection = reader["affection"].ToString()
                        };
                        list_antecedantMaladice.Add(antecedantMaladie);
                    }
                }
            }

            return list_antecedantMaladice;
        }
    }
}
