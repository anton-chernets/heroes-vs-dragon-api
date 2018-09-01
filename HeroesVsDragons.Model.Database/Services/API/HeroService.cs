using System;
using System.Collections.Generic;
using System.Linq;
using HeroesVsDragons.Model.API.ModelLayer.Unit.Models;
using HeroesVsDragons.Model.API.Services;
using HeroesVsDragons.Model.Helpers;

namespace HeroesVsDragons.Model.Database.Services.API
{
    /// <summary>
    /// Service Hero.
    /// </summary>
    public class HeroService : BaseService, IHeroService
    {
        private readonly List<HeroUnitModel> _heroes = new List<HeroUnitModel>
        {
            new HeroUnitModel("he") { Id= 1, Created_at= DateHelper.DateTimeToUnixTimestamp(DateTime.Now), Weapon = 4 },
            new HeroUnitModel("heroName1") { Id= 2, Created_at= DateHelper.DateTimeToUnixTimestamp(DateTime.Now), Weapon = 5 },
            new HeroUnitModel("heroName2") { Id= 3, Created_at= DateHelper.DateTimeToUnixTimestamp(DateTime.Now), Weapon = 6 },
        };

        public List<HeroUnitModel> GetHeroesList(string filter = null)
        {
            return _heroes;
        }

        public HeroUnitModel CreateHero(string name)
        {

            var hero = new HeroUnitModel(name);

            _heroes.Add(hero);
            return hero;
        }
    }
}
