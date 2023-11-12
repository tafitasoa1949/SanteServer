using System.Data.SqlClient;

namespace Sante.Models
{
    public class Vola
    {
        public int code { get; set; }
        public string nom { get; set; }
        public static List<Vola> getList(SqlConnection connection)
        {
            List<Vola> list_Vola = new List<Vola>();
            string query = "SELECT * FROM vola";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Vola money = new Vola
                        {
                            code = Convert.ToInt32(reader["code"]),
                            nom = reader["nom"].ToString()
                        };
                        list_Vola.Add(money);
                    }
                }
            }

            return list_Vola;
        }
    }
}
