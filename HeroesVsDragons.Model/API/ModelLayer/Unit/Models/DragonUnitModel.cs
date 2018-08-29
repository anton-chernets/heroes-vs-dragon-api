using System;
using HeroesVsDragons.Model.Helpers;

namespace HeroesVsDragons.Model.API.ModelLayer.Unit.Models
{
    public class DragonUnitModel : BaseUnitModel
    {
        public int Lives { get; set; }

        public DragonUnitModel()
        {
            this.Name = NameHelper.GenerateName(RandomHelper.GetRandomNumber(5, 16));
            this.Created_at = DateHelper.DateTimeToUnixTimestamp(DateTime.Now);
            this.Lives = RandomHelper.GetRandomNumber(80, 100);
        }
    }
}
