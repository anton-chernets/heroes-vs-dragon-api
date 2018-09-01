using System;
using System.Collections.Generic;
using HeroesVsDragons.Model.API.ModelLayer.Unit.Models;
using Microsoft.AspNetCore.Mvc;

namespace HeroesVsDragons.ApiControllers.API.Interfaces
{
    /// <summary>
    /// Interface for heroes controller.
    /// </summary>
    public interface IHeroesController
    {
        ActionResult<IList<HeroUnitModel>> Get();
        object Post([FromBody] string name);
    }
}
