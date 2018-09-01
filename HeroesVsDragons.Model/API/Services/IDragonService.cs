using System.Collections.Generic;
using HeroesVsDragons.Model.API.ModelLayer.Unit.Models;

namespace HeroesVsDragons.Model.API.Services
{
    public interface IDragonService
    {
        List<DragonUnitModel> GetDragonsList(string filter = null);
        DragonUnitModel GetDragonById(long id);
        DragonUnitModel CreateDragon();
    }
}
