using System.Data.SqlClient;

namespace Sante.Models
{
    public class Devise
    {
        public Vola vola { get; set; }
        public float coursAr { get; set; }
        public float tauxvente { get; set; }
        public DateTime dateheure { get; set; }

        public static Devise getDevise(SqlConnection connection, DateTime date,string code)
        {
            Devise devise = null;
            string sql = "select top 1 d.code as code1,d.coursAr,d.tauxvente,d.dateheure,v.code,v.nom from devise  as d join vola as v on v.code=d.code where d.code=@code order by d.dateheure desc ";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
               // command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@code", code);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Vola new_vola = new Vola
                        {
                            code = Convert.ToInt32(reader["code"]),
                            nom = reader["nom"].ToString()
                        };
                        devise = new Devise
                        {
                            vola = new_vola,
                            coursAr = (float)Convert.ToDecimal(reader["coursAr"]),
                            tauxvente= (float)Convert.ToDecimal(reader["tauxvente"]),
                            dateheure = Convert.ToDateTime(reader["dateheure"])
                        };

                    }
                }
            }
            return devise;
        }
    }
}
