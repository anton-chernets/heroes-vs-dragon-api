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
using HeroesVsDragons.Model.API.ModelLayer.Unit.Models;

namespace HeroesVsDragons.ApiControllers.API
{
    public class TokenResponse
    {
        public string Token { get; set; }
        public string Username { get; set; }
    }
    /// <summary>
    /// Controller for JWT.
    /// </summary>
    public class AccountController : Controller
    {
        [HttpPost("/token")]
        public async Task<TokenResponse> TokenAsync([FromBody]string username)
        {
            TokenResponse result = new TokenResponse();

            ClaimsIdentity identity = GetIdentity(username);
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
                result.Username = username;

                //var response = new
                //{
                //    access_token = encodedJwt,
                //    username = identity.Name
                //};
            }
            else
            {
                
            }

           

            // сериализация ответа
            //Response.ContentType = "application/json";
            //await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));

            return result;
        }

        private ClaimsIdentity GetIdentity(string username)
        {
            return null;// если пользователя не найдено
        }
    }
}