using System.ComponentModel.DataAnnotations;

namespace Projet3.Models
{
    public class LoginLecteurViewModel
    {
        [Required]
        [Display(Name = "Identifiant / Courrier électronique")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }
    }

    public class CreateLecteurViewModel
    {
        [Required]
        [Display(Name = "Pseudo")]
        public string pseudo { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [Display(Name = "Mot de passe")]
        public string password { get; set; }

        [Required]
        [Display(Name = "Confirmation de mot de passe")]
        [Compare(nameof(password), ErrorMessage = "Les deux champs mot de passe ne correspondent pas")]
        public string confirm { get; set; }

    }
}