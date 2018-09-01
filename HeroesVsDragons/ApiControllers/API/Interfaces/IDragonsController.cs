using System;
using System.Collections.Generic;
using HeroesVsDragons.Model.API.ModelLayer.Unit.Models;
using HeroesVsDragons.Model.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace HeroesVsDragons.ApiControllers.API.Interfaces
{
    /// <summary>
    /// Interface for dragons controller.
    /// </summary>
    public interface IDragonsController
    {
        ActionResult<IList<DragonUnitModel>> Get ();
        ActionResult<Object> Get(long id);
        object Post();
    }
}
