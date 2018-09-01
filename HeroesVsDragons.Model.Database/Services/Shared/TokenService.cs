using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HeroesVsDragons.Model.Shared;
using HeroesVsDragons.Model.API.ModelLayer.Auth.Models;
using HeroesVsDragons.Model.API.ModelLayer.Unit.Models;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using HeroesVsDragons.Model.Database.Options;
using Microsoft.IdentityModel.Tokens;

namespace HeroesVsDragons.Model.Database.Services.Shared
{
    public class TokenService : ITokenService
    {
        ///<summary>
        /// Method get token for Auth.
        /// </summary>
        TokenResponseModel ITokenService.CreateTokenAsync(string name)
        {
            TokenResponseModel result = new TokenResponseModel();

            var claims = new List<Claim> {

            };

            ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            var now = DateTime.UtcNow;

            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: claimsIdentity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            result.Token = encodedJwt;
            result.Name = name;

            return result;
        }
    }
}
