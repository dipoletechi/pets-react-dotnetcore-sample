namespace CMSWebAPI.Models.Api.Owner
{
    public class OwnerStats
    {
        public int TotalOwners { get; set; }
        public int TotalPets { get; set; }
        public float AverageNumberOfAnimalsPerOwner { get; set; }
        public string AverageAgeOfAnimals { get; set; }
    }
}
