using System.Collections.Generic;

namespace CMSWebAPI.Models.Api.Owner
{
    public class OwnerModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public List<PetModel> Dogs {get;set;}
        public List<PetModel> Cats { get; set; }
    }
}

