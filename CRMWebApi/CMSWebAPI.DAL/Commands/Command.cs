using System.Data.SqlClient;

namespace CMSWebAPI.DAL.Commands
{
    public class Command
    {
        public SqlConnection dbConnection;
        public Command()
        {
            dbConnection = new SqlConnection("Server=DTICP-8;Initial Catalog=testdb;Trusted_Connection=True;MultipleActiveResultSets=true;");
        }
    }
}