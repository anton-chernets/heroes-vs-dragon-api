using System.Collections.Generic;
using HeroesVsDragons.Model.API.ModelLayer.Unit.Models;

namespace HeroesVsDragons.Model.API.Services
{
    public interface IHeroService
    {
        List<HeroUnitModel> GetHeroesList(string filter = null);
        HeroUnitModel CreateHero(string name);
    }
}
