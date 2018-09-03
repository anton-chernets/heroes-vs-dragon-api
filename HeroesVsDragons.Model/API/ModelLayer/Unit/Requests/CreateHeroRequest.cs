using System;
using System.ComponentModel.DataAnnotations;
using HeroesVsDragons.Model.Constants;

namespace HeroesVsDragons.Model.API.ModelLayer.Unit.Requests
{
    public class CreateHeroRequest
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(ValidationsLengthConstants.MaxLengthName, MinimumLength = ValidationsLengthConstants.MinLengthName, ErrorMessage = "Name cannot be longer than 20 characters and less than 4")]
        public string Name { get; set; }
    }
}
