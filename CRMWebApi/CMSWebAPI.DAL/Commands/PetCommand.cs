using System;
using System.Data.SqlClient;

namespace CMSWebAPI.DAL.Commands
{
    public class PetCommand:Command
    {
        public void Feed(int Id)
        {           
            string sql = "UPDATE Pets SET Feedings=Feedings+1 WHERE Id=" + Id;
            var command = new SqlCommand(sql, dbConnection);

            //opening connection and executing the query
            dbConnection.Open();
            command.ExecuteNonQuery();
            dbConnection.Close();            
        }


        public int TotalPets()
        {
            string sql = "SELECT count(*) as total FROM Pets";
            SqlCommand command = new SqlCommand(sql, dbConnection);
            dbConnection.Open();
            var result = command.ExecuteScalar();
            dbConnection.Close();
            return (Int32)result;
        }
    }
}

