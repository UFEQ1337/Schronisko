using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Schronisko.Models;

public class Animal
{
    public int AnimalId { get; set; }
    [Required(ErrorMessage ="Pole jest wymagane")]
    [MaxLength(50)]
    [Display (Name = "Imię")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Pole jest wymagane")]
    [Display(Name = "Rasa")]
    [MaxLength(25)]
    public string Breed { get; set; }
    [Display(Name = "Do adopcji")]
    public bool ForAdoption { get; set; }
    [Required(ErrorMessage = "Pole jest wymagane")]
    [Display(Name = "Wiek")]
    [Range(0, double.MaxValue, ErrorMessage ="Wartość musi być nieujemna.")]
    public int Age { get; set; }
    [Display(Name = "Id Schroniska")]

    public int ShelterId { get; set; }

    public virtual Shelter? Shelter { get; set; }
    public string? UserId { get; set; }
    public virtual IdentityUser? User { get; set; }
}