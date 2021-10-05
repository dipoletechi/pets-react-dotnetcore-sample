using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CMSWebAPI.DAL.Commands;
using CMSWebAPI.Models.Api.Owner;
using System.Collections.Generic;
using System.Globalization;

namespace CMSWebAPI.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/owner")]
    public class OwnerController
    {
        public OwnerController()
        {

        }


        //[HttpPost]
        //public object Post([FromBody]UserModel user)
        //{
        //    try
        //    {                              
        //        return "";
        //    }
        //    catch (Exception ex)
        //    {
        //        return "";
        //    }
        //}


        [HttpGet]
        [Route("all")]
        public object GetAll()
        {
            var owners = new List<OwnerModel>();
            var ownerCommand = new OwnerCommand();
            owners = ownerCommand.GetOwners().ToList().Select(o => new OwnerModel
            {
                Id = o.Id,
                Address = o.Address,
                Email = o.Email,
                FullName = o.FullName,
                Phone = o.Phone
            }).ToList();

            return owners;
        }


        [HttpGet]
        [Route("getstats/{ownerids}")]
        public object GetStats(string ownerIds)
        {
            var stats = new OwnerStats();
            var ownerCommand = new OwnerCommand();
            stats.TotalOwners = ownerCommand.TotalOwners();
            var ownerPets = ownerCommand.GetOwnerPetInfo(ownerIds);
            var ownerPetsCount = ownerPets.GroupBy(p => p.OwnerId).Select(p => new
            {
                ownerId = p.Key,
                totalPets = p.Count()
            });

            double totalAge = 0;
            foreach (var pet in ownerPets)
            {
                totalAge += (DateTime.Now - pet.DOB).TotalSeconds;
            }
            var petCommand = new PetCommand();
            stats.TotalPets = petCommand.TotalPets();
            stats.AverageNumberOfAnimalsPerOwner = (ownerPetsCount.Sum(p => p.totalPets) / ownerPetsCount.Count());

            stats.AverageAgeOfAnimals = GetAverageFormatted(totalAge / ownerPets.Count());
            return stats;
        }



        [HttpGet]
        [Route("getownerinfo/{ownerId}")]
        public object GetOwnerInfo(int ownerId)
        {
            var owner = new OwnerModel();
            var ownerCommand = new OwnerCommand();
            var ownerInfo = ownerCommand.GetOwnerInfo(ownerId);
            var ownerPetInfo = ownerCommand.GetOwnerPetInfo(ownerId);
            owner = new OwnerModel
            {

                Address = ownerInfo.Address,
                FullName = ownerInfo.FullName,
                Email = ownerInfo.Email,
                Phone = ownerInfo.Phone,
                Id = ownerInfo.Id,
                Dogs = ownerPetInfo.Where(p => p.PetType == 1).Select(po => new PetModel
                {
                    Id = po.Id,
                    Color = po.Color,
                    DOB = po.DOB.ToString("dd-MM-yyyy"),
                    Age = GetAge(po.DOB),
                    Feedings = po.Feedings,
                    LevelOfTraining = po.Feedings,
                    Name = po.Name,
                    Notes = po.Notes,
                    PetType = po.PetType,
                    SupposedHigh = po.SupposedHigh
                }).ToList(),
                Cats = ownerPetInfo.Where(p => p.PetType == 0).Select(po => new PetModel
                {
                    Id = po.Id,
                    CatchingMouses = po.CatchingMouses ? "Yes" : "No",
                    Color = po.Color,
                    DOB = po.DOB.ToString("dd-MM-yyyy"),
                    Age = GetAge(po.DOB),
                    Feedings = po.Feedings,
                    LevelOfTraining = po.Feedings,
                    Name = po.Name,
                    Notes = po.Notes,
                    PetType = po.PetType,
                    SupposedHigh = po.SupposedHigh
                }).ToList()
            };

            return owner;
        }

        private string GetAge(DateTime dob)
        {
            DateTime today = DateTime.Today;

            int months = today.Month - dob.Month;
            int years = today.Year - dob.Year;

            if (today.Day < dob.Day)
            {
                months--;
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }

            int days = (today - dob.AddMonths((years * 12) + months)).Days;

            return string.Format("{0} year{1}, {2} month{3} and {4} day{5}",
                                 years, (years == 1) ? "" : "s",
                                 months, (months == 1) ? "" : "s",
                                 days, (days == 1) ? "" : "s");
        }

        private string GetAverageFormatted(double seconds)
        {
            TimeSpan diff = TimeSpan.FromSeconds(seconds);
            return string.Format(
                      CultureInfo.CurrentCulture,
                      "{0} years, {1} months, {2} days, {3} hours, {4} minutes, {5} seconds",
                      diff.Days / 365,
                      (diff.Days - (diff.Days / 365) * 365) / 30,
                      (diff.Days - (diff.Days / 365) * 365) - ((diff.Days - (diff.Days / 365) * 365) / 30) * 30,
                      diff.Hours,
                      diff.Minutes,
                      diff.Seconds);

        }
    }
}
