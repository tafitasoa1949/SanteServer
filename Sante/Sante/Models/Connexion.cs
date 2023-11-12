

using System.Data.SqlClient;

namespace Sante.Models
{
    public class Connexion
    {
        public static SqlConnection getConnection()
        {
            string connectionString = "Data Source=TAFITASOA-P15B-\\SQLEXPRESS;Initial Catalog=santeserver;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectionString);
                return connection; 
        }
    }
}
