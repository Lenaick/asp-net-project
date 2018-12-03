using System.ComponentModel.DataAnnotations;

namespace Projet3.Models
{
    public class LoginLecteurViewModel
    {
        [Required]
        [Display(Name = "Identifiant / Courrier électronique")]
        [EmailAddress]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }
    }
}