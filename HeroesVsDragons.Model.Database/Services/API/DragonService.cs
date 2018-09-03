using System;
using System.Collections.Generic;
using System.Linq;
using HeroesVsDragons.Model.API.ModelLayer.Unit.Models;
using HeroesVsDragons.Model.API.Services;
using HeroesVsDragons.Model.Database.HeadLog;
using HeroesVsDragons.Model.Helpers;

namespace HeroesVsDragons.Model.Database.Services.API
{
    /// <summary>
    /// Service Dragon.
    /// </summary>
    public class DragonService : BaseService, IDragonService
    {
        private readonly List<DragonUnitModel> _dragons = new List<DragonUnitModel>
        {
            new DragonUnitModel { Id= 1, Name="somename", Created_at= DateHelper.DateTimeToUnixTimestamp(DateTime.Now), Lives = 99 },
            new DragonUnitModel { Id= 2, Name="somename2", Created_at= DateHelper.DateTimeToUnixTimestamp(DateTime.Now), Lives = 98 },
            new DragonUnitModel { Id= 3, Name="somename3", Created_at= DateHelper.DateTimeToUnixTimestamp(DateTime.Now), Lives = 100 },
        };

        public DragonService(IHeadLog headLog) : base(headLog)
        {
        }

        public List<DragonUnitModel> GetDragonsList(string filter = null)
        {
            return _dragons;
        }

        public DragonUnitModel GetDragonById(long id)
        {
            return _dragons.FirstOrDefault(x => x.Id == id);
        }

        public DragonUnitModel CreateDragon()
        {
            var dragon = new DragonUnitModel();

            _dragons.Add(dragon);
            return dragon;
        }
    }
}