using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HeroesVsDragons.Model.API.ModelLayer.Unit.Models;
using HeroesVsDragons.Model.API.Services;
using HeroesVsDragons.Model.Database.Services.API;
using Microsoft.AspNetCore.Authorization;

namespace HeroesVsDragons.ApiControllers.API
{
    /// <summary>
    /// Controller for dragon.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DragonsController : ControllerBase
    {
        /// <summary>
        /// Some coment.
        /// </summary>
        private readonly IDragonService _dragonService;

        /// <summary>
        /// Some coment.
        /// </summary>
        public DragonsController(IDragonService dragonService)
        {
            _dragonService = dragonService;
        }

        /// <summary>
        /// GET api/dragons
        /// </summary>
        [Authorize]
        [HttpGet]
        public ActionResult<IList<DragonUnitModel>> Get()
        {
            return _dragonService.GetDragonsList();
        }

        /// <summary>
        /// GET api/dragons vs id param
        /// </summary>
        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<Object> Get(long id)
        {
            return _dragonService.GetDragonById(id);
        }

        /// <summary>
        /// Post api/dragons set dragon
        /// </summary>
        [Authorize]
        [HttpPost]
        public object Post()
        {
            return _dragonService.CreateDragon();
        }
    }
}
