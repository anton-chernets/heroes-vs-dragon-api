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
using HeroesVsDragons.Model.Shared;

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
        private readonly IHeroService _heroService;
        /// <summary>
        /// Some coment.
        /// </summary>
        private readonly ITokenService _tokenService;

        /// <summary>
        /// Some coment.
        /// </summary>
        public HeroesController(IHeroService heroService, ITokenService tokenService)
        {
            _heroService = heroService;
            _tokenService = tokenService;
        }

        /// <summary>
        /// GET api/heroes
        /// </summary>
        [Authorize]
        [HttpGet]
        public ActionResult<IList<HeroUnitModel>> Get()
        {
            return _heroService.GetHeroesList();
        }

        /// <summary>
        /// POST api/heroes set hero
        /// </summary>
        [HttpPost]
        public object Post([FromBody] string name)
        {
            try
            {
                HeroUnitModel hero = _heroService.CreateHero(name);
                return _tokenService.CreateTokenAsync(hero.Name);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " hero not created");
            }
        }
    }
}
