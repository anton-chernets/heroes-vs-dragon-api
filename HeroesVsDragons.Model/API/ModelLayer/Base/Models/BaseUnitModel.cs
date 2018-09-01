using System;
using System.ComponentModel.DataAnnotations;

namespace HeroesVsDragons.Model
{
    public abstract class BaseUnitModel
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Name cannot be longer than 20 characters and less than 4")]
        public string Name { get; set; }
        public double Created_at { get; set; }
    }
}
