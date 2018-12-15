using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Projet3.Models
{
    public class LoginLecteurViewModel
    {
        [Required]
        [Display(Name = "Pseudo / Email")]
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
        [Remote("UniquePseudoExist", "Account",
                ErrorMessage = "Un compte possède déjà ce pseudo")]
        public string pseudo { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        [Remote("UniqueEmailExist", "Account",
                ErrorMessage = "Un compte possède déjà cette email")]
        public string email { get; set; }

        [Required]
        [Display(Name = "Mot de passe")]
        public string password { get; set; }

        [Required]
        [Display(Name = "Confirmation de mot de passe")]
        [System.ComponentModel.DataAnnotations.Compare(nameof(password),
            ErrorMessage = "Les deux champs mot de passe ne correspondent pas")]
        public string confirm { get; set; }

    }
}