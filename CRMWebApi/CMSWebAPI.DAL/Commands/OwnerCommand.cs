using CMSWebAPI.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CMSWebAPI.DAL.Commands
{
    public class OwnerCommand:Command
    {
        public List<Pet> GetOwnerPetInfo(int Id)
        {
            var pets = new List<Pet>();
            string sql = "Select p.Feedings, p.DOB, p.Name, p.Color, p.Notes, p.LevelOfTraining, p.PetType, p.SupposedHigh, p.CatchingMouses, p.Id From PetsVSOwners as po Join Pets as p on p.Id = po.PetId WHERE  po.OwnerId="+ Id;
            SqlCommand command = new SqlCommand(sql, dbConnection);

            //opening connection and executing the query
            dbConnection.Open();        

            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    pets.Add(new Pet
                    {
                        Feedings= (int)dataReader.GetValue(0),
                        DOB = (DateTime)dataReader.GetValue(1),
                        Name = (string)dataReader.GetValue(2),
                        Color = (string)dataReader.GetValue(3),
                        Notes = (string)dataReader.GetValue(4),
                        LevelOfTraining = (int)dataReader.GetValue(5),
                        SupposedHigh = (int)dataReader.GetValue(7),
                        CatchingMouses = (bool)dataReader.GetValue(8),
                        Id = (int)dataReader.GetValue(9),
                        PetType = Convert.ToInt32(dataReader.GetValue(6))
                    });                   
                }
            }
            dbConnection.Close();
            return pets;
        }


        public List<Owner> GetOwners()
        {
            var owners = new List<Owner>();
            string sql = "SELECT * FROM Owners";
            SqlCommand command = new SqlCommand(sql, dbConnection);

            //opening connection and executing the query
            dbConnection.Open();
            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    var owner = new Owner();
                    owner.Id = (int)dataReader.GetValue(0);
                    owner.FullName = Convert.ToString(dataReader.GetValue(3));
                    owner.Email = Convert.ToString(dataReader.GetValue(4));
                    owner.Phone = Convert.ToString(dataReader.GetValue(5));
                    owner.Address = Convert.ToString(dataReader.GetValue(6));
                    owners.Add(owner);
                }
            }
            dbConnection.Close();
            return owners;
        }


        public int TotalOwners()
        {           
            string sql = "SELECT count(*) as totalOwners FROM Owners";
            SqlCommand command = new SqlCommand(sql, dbConnection);        
            dbConnection.Open();
            var result = command.ExecuteScalar();
            dbConnection.Close();
            return (Int32)result;
        }


        public List<Pet> GetOwnerPetInfo(string ownerIds)
        {
            var pets = new List<Pet>();
            string sql = "Select p.Feedings, p.DOB, p.Name, p.Color, p.Notes, p.LevelOfTraining, p.PetType, p.SupposedHigh, p.CatchingMouses, p.Id, po.OwnerId From PetsVSOwners as po Join Pets as p on p.Id = po.PetId WHERE  po.OwnerId IN (" + ownerIds + ")";
            SqlCommand command = new SqlCommand(sql, dbConnection);

            //opening connection and executing the query
            dbConnection.Open();

            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    pets.Add(new Pet
                    {
                        Feedings = (int)dataReader.GetValue(0),
                        DOB = (DateTime)dataReader.GetValue(1),
                        Name = (string)dataReader.GetValue(2),
                        Color = (string)dataReader.GetValue(3),
                        Notes = (string)dataReader.GetValue(4),
                        LevelOfTraining = (int)dataReader.GetValue(5),
                        SupposedHigh = (int)dataReader.GetValue(7),
                        CatchingMouses = (bool)dataReader.GetValue(8),
                        Id = (int)dataReader.GetValue(9),
                        PetType = Convert.ToInt32(dataReader.GetValue(6)),
                        OwnerId = Convert.ToInt32(dataReader.GetValue(10)),
                    });
                }
            }
            dbConnection.Close();
            return pets;
        }

        public Owner GetOwnerInfo(int Id)
        {
            var owner = new Owner();
            string sql = "SELECT * FROM Owners WHERE Id="+ Id;
            SqlCommand command = new SqlCommand(sql, dbConnection);

            //opening connection and executing the query
            dbConnection.Open();
            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    owner.Id =(int) dataReader.GetValue(0);
                    owner.FullName =Convert.ToString(dataReader.GetValue(3));
                    owner.Email = Convert.ToString(dataReader.GetValue(4));
                    owner.Phone = Convert.ToString(dataReader.GetValue(5));
                    owner.Address = Convert.ToString(dataReader.GetValue(6));                    
                }
            }
            dbConnection.Close();
            return owner;
        }
    }
}

