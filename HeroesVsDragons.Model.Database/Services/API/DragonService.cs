using System;
using HeroesVsDragons.Model.API.ModelLayer.Unit.Models;
using HeroesVsDragons.Model.API.Services;

namespace HeroesVsDragons.Model.Database.Services.API
{
    /// <summary>
    /// Service Dragon.
    /// </summary>
    public class DragonService : BaseService, IDragonService
    {
        public static object GetDragonById(long id)
        {
            object dragon = new DragonUnitModel();
            return id == 1 ? dragon : null;
        }

        public static object CreateDragon()
        {
            return new DragonUnitModel();
        }
    }
}
