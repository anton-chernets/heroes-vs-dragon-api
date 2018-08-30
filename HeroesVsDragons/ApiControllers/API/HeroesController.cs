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

namespace HeroesVsDragons.Controllers
{
    /// <summary>
    /// Controller for hero.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase, IHeroesController
    {
        /// <summary>
        /// Some coment.
        /// </summary>
        private readonly IHeroService _itemService;

        /// <summary>
        /// GET api/heroes
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "item1", "item2" };
        }

        /// <summary>
        /// POST api/heroes set hero
        /// </summary>
        [HttpPost]
        public object Post([FromBody] string name)
        {
            return HeroService.CreateHero(name);
        }
    }
}
