using System.Data.SqlClient;

namespace Evant.DAL.Helper
{
    public class ConnectionHelper
    {
        public SqlConnection connection;


        public ConnectionHelper()
        {
            connection = new SqlConnection("server=MAC-PRO;database=Evant;Trusted_Connection=true;MultipleActiveResultSets=True;");
        }

    }
}