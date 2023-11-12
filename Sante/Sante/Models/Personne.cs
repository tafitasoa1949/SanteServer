using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Sante.Models
{
    public class Personne
    {
        public int cin { get; set; }
        public string nom { get; set; }
        public string prenoms { get; set; }
        public DateTime dateNaissance { get; set; }
        public string sexe { get; set; }
        public string adresser { get; set; }
        public string email { get; set; }
        public string contact { get; set; }

        public static List<Personne> getListPersonne(SqlConnection connection)
        {
            List<Personne> personnes = new List<Personne>();
            string query = "SELECT * FROM personne";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Personne personne = new Personne
                        {
                            cin = Convert.ToInt32(reader["cin"]),
                            nom = reader["nom"].ToString(),
                            prenoms = reader["prenoms"].ToString(),
                            dateNaissance = Convert.ToDateTime(reader["datedenaissance"]),
                            sexe = reader["sexe"].ToString(),
                            adresser = reader["adresser"].ToString(),
                            email = reader["email"].ToString(),
                            contact = reader["contact"].ToString()
                        };
                        personnes.Add(personne);
                    }
                }
            }

            return personnes;
        }
        public static Personne getPersonne(SqlConnection connection, int cin)
        {
            Personne pers = null;
            string sql = "select * from personne where cin = @cin";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@cin", cin);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        pers = new Personne
                        {
                            cin = Convert.ToInt32(reader["cin"]),
                            nom = reader["nom"].ToString(),
                            prenoms = reader["prenoms"].ToString(),
                            dateNaissance = Convert.ToDateTime(reader["datedenaissance"]),
                            sexe = reader["sexe"].ToString(),
                            adresser = reader["adresser"].ToString(),
                            email = reader["email"].ToString(),
                            contact = reader["contact"].ToString()
                        };

                    }
                }
            }
            return pers;
        }
        public static Boolean ifExistPersonne(SqlConnection connection,int cin)
        {
            Boolean result = false;
            string sql = "select 1 from personne where cin = @cin";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@cin", cin);
                // Utilisation de ExecuteScalar pour vérifier l'existence sans récupérer de données
                object exists = command.ExecuteScalar();

                if (exists != null && exists != DBNull.Value)
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
