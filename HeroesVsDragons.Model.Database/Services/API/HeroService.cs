using System;
using System.Collections.Generic;
using System.Linq;
using HeroesVsDragons.Model.API.ModelLayer.Unit.Models;
using HeroesVsDragons.Model.API.ModelLayer.Unit.Requests;
using HeroesVsDragons.Model.API.Services;
using HeroesVsDragons.Model.Database.HeadLog;
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

        /// <summary>
        /// Initializes a new instance of the <see cref="T:HeroesVsDragons.Model.Database.Services.API.HeroService"/> class.
        /// </summary>
        /// <param name="headLog">Head log.</param>
        public HeroService(IHeadLog headLog) : base(headLog)
        {
        }

        public List<HeroUnitModel> GetHeroesList(string filter = null)
        {
            return _heroes;
        }

        public AOResult<HeroUnitModel> CreateHero(CreateHeroRequest createHeroRequest)
        => BaseInvoke<HeroUnitModel>((aoResult) =>
        {
            var hero = new HeroUnitModel(createHeroRequest.Name);

            _heroes.Add(hero);
            aoResult.SetSuccess(hero);
        }, createHeroRequest);
    }
}
