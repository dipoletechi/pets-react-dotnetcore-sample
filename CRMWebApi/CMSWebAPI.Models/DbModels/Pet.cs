using System;
using System.Collections.Generic;

namespace CMSWebAPI.Models.DbModels
{
    public class Pet
    {
        public int Id { get; set; }
        public int Feedings { get; set; }
        public DateTime DOB { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Notes { get; set; }
        /// <summary>
        ///1-10 , for dog 
        /// </summary>
        public int LevelOfTraining { get; set; }
        /// <summary>
        ///0=cat, 1=dog
        /// </summary>
        public int PetType { get; set; }

        /// <summary>
        ///in centimeters -- dog 
        /// </summary>
        public int SupposedHigh { get; set; }

        /// <summary>
        /// for cat only
        /// </summary>
        public bool CatchingMouses { get; set; }

        public int OwnerId { get; set; }

    }
}