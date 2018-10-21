using System;
using HeroesVsDragons.Model.API.Services;
using HeroesVsDragons.Model.Database.HeadLog;

namespace HeroesVsDragons.Model.Database.Services.API
{
    public class HitService : BaseService, IHitService
    {
        public HitService(IHeadLog headLog) : base(headLog)
        {
        }
    }
}
