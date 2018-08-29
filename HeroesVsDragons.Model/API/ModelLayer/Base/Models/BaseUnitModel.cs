using System;

namespace HeroesVsDragons.Model
{
    public abstract class BaseUnitModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Created_at { get; set; }
    }
}
