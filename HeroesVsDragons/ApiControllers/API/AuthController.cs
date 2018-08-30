using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json;
using System.Security.Claims;
using HeroesVsDragons.Model.API.ModelLayer.Auth.Models;
using HeroesVsDragons.Model.API.ModelLayer.Unit.Models;
using HeroesVsDragons.Model.Database.Services.API;

namespace HeroesVsDragons.ApiControllers.API
{
    /// <summary>
    /// Controller for JWT.
    /// </summary>
    public class AuthController : Controller
    {
        [HttpPost("api/token")]
        public async Task<TokenResponseModel> TokenAsync([FromBody]string name)
        {
            TokenResponseModel result = new TokenResponseModel();

            ClaimsIdentity identity = GetIdentity(name);

            if (identity != null)
            {
                var now = DateTime.UtcNow;

                // создаем JWT-токен
                var jwt = new JwtSecurityToken(
                        issuer: AuthOptions.ISSUER,
                        audience: AuthOptions.AUDIENCE,
                        notBefore: now,
                        claims: identity.Claims,
                        expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                result.Token = encodedJwt;
                result.Name = name;
            }

            return result;
        }

        private ClaimsIdentity GetIdentity(string name)
        {
            HeroUnitModel hero = new HeroUnitModel(name);

            var claims = new List<Claim> { };
            ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }
    }
}
