using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CMSWebAPI.DAL.Commands;
using CMSWebAPI.Models.Api.Owner;
using System.Collections.Generic;

namespace CMSWebAPI.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/pet")]
    public class PetController
    {
        [HttpPost]
        [Route("feed/{petId}")]
        public object FeedPet(int petId)
        {
            new PetCommand().Feed(petId);
            return true;
        }

    }
}
