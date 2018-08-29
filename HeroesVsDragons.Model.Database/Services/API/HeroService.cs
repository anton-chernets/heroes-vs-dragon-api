using HeroesVsDragons.Model.API.ModelLayer.Unit.Models;
using HeroesVsDragons.Model.API.Services;

namespace HeroesVsDragons.Model.Database.Services.API
{
    /// <summary>
    /// Service Hero.
    /// </summary>
    public class HeroService : BaseService, IHeroService
    {
        public static object GetHeroById(long id)
        {
            object hero = new HeroUnitModel("Test");
            return id == 1 ? hero : null;
        }

        public static object CreateHero(string name)
        {
            return new HeroUnitModel(name);
        }
    }
}
