using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HeroesVsDragons.Model.API.ModelLayer.Unit.Models;
using HeroesVsDragons.ApiControllers.API.Interfaces;
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
    public class DragonsController : ControllerBase, IDragonsController
    {
        /// <summary>
        /// Some coment.
        /// </summary>
        private readonly IDragonService _itemService;

        /// <summary>
        /// GET api/dragons
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "item1", "item2" };
        }

        /// <summary>
        /// GET api/dragons vs id param
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<Object> Get(long id)
        {
            return DragonService.GetDragonById(id);
        }

        /// <summary>
        /// Post api/dragons set dragon
        /// </summary>
        [Authorize]
        [HttpPost]
        public object Post()
        {
            return DragonService.CreateDragon();
        }
    }
}
