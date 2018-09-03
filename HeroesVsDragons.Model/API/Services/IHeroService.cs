using System.Collections.Generic;
using HeroesVsDragons.Model.API.ModelLayer.Unit.Models;
using HeroesVsDragons.Model.API.ModelLayer.Unit.Requests;

namespace HeroesVsDragons.Model.API.Services
{
    public interface IHeroService
    {
        List<HeroUnitModel> GetHeroesList(string filter = null);
        AOResult<HeroUnitModel> CreateHero(CreateHeroRequest createHeroRequest);
    }
}
