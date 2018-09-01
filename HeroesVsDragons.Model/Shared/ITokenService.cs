using System;
using HeroesVsDragons.Model.API.ModelLayer.Auth.Models;

namespace HeroesVsDragons.Model.Shared
{
    public interface ITokenService
    {
        TokenResponseModel CreateTokenAsync(string name);
    }
}
