using System;
using HeroesVsDragons.Model.Helpers;

namespace HeroesVsDragons.Model.API.ModelLayer.Unit.Models
{
    public class HeroUnitModel : BaseUnitModel
    {
        public int Weapon { get; set; }

        public HeroUnitModel(string name)
        {
            this.Name = name;
            this.Created_at = DateHelper.DateTimeToUnixTimestamp(DateTime.Now);
            this.Weapon = RandomHelper.GetRandomNumber(1, 6);
        }
    }
}
