using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HeroesVsDragons.Model.API.ModelLayer.Unit.Models;
using HeroesVsDragons.Model.API.Services;
using HeroesVsDragons.Model.Database.Services.API;
using Microsoft.AspNetCore.Authorization;
using HeroesVsDragons.Model.Shared;
using HeroesVsDragons.Model;
using HeroesVsDragons.Model.API.ModelLayer.Auth.Models;
using HeroesVsDragons.Model.API.ModelLayer.Unit.Requests;

namespace HeroesVsDragons.Controllers
{
    /// <summary>
    /// Controller for hero.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
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
        public TokenResponseModel Post([FromBody] CreateHeroRequest createHeroRequest)
        {
            TokenResponseModel token = null;

            try
            {
                AOResult<HeroUnitModel> heroResult = _heroService.CreateHero(createHeroRequest);
                if (heroResult.IsSuccess)
                {
                    token = _tokenService.CreateTokenAsync(heroResult.Result.Name);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " hero not created");
            }

            return token;
        }
    }
}
