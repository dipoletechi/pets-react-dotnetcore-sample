using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSWebAPI.Models.Api.Owner
{
    public class PetModel
    {
        public int Id { get; set; }
        public int Feedings { get; set; }
        public string DOB { get; set; }
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
        public String CatchingMouses { get; set; }    
        
        public string Age { get; set; }
    }
}
