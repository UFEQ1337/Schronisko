using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Schronisko.Models;

public class Shelter
{
    [Display(Name = "Id schroniska")]
    public int ShelterId { get; set; }
    [Display(Name = "Nazwa schroniska")]
    [Required(ErrorMessage = "Pole jest wymagane.")]
    public string ShelterName { get; set; }
    [Required(ErrorMessage = "Pole jest wymagane.")]
    [Display(Name = "Adres schroniska")]
    public string ShelterAddress { get; set; }
    public string? UserId { get; set; }
    public virtual IdentityUser? User { get; set; }
}