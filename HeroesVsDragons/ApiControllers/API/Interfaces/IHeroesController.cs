using System;
using System.Collections.Generic;
using HeroesVsDragons.Model.API.ModelLayer.Auth.Models;
using HeroesVsDragons.Model.API.ModelLayer.Unit.Models;
using HeroesVsDragons.Model.API.ModelLayer.Unit.Requests;
using Microsoft.AspNetCore.Mvc;

namespace HeroesVsDragons.ApiControllers.API.Interfaces
{
    /// <summary>
    /// Interface for heroes controller.
    /// </summary>
    public interface IHeroesController
    {
        ActionResult<IList<HeroUnitModel>> Get();
        TokenResponseModel Post([FromBody] CreateHeroRequest createHeroRequest);
    }
}