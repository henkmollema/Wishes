using System.Data;
using System.Data.SqlClient;

namespace Wishes.Core.Data
{
    public class Database
    {
        private const string ConnectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Wishes.mdf;Integrated Security=True";

        public static IDbConnection GetOpenConnection()
        {
            var con = new SqlConnection(ConnectionString);
            con.Open();
            return con;
        }
    }
}
