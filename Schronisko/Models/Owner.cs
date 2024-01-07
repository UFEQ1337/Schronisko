using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schronisko.Models
{
    public class Owner
    {
        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Id Właściciela")]
        public int OwnerId { get; set; }
        [Required(ErrorMessage ="Pole jest wymagane")]
        [Display(Name = "Właściciel")]
        [MaxLength(25)]
        public string OwnerName { get; set; }
        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Czas adopcji")]
        public DateTime AdoptionTime { get; set; }
        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Id zwierzaka")]
        public int AnimalId { get; set; }
        [Display(Name = "Zwierzak")]
        public virtual Animal? Animal { get; set; }
        [Display(Name = "Id użytkownika")]
        public string? UserId { get; set; }
        [Display(Name = "Użytkownik")]
        public virtual IdentityUser? User { get; set; }
    }
}