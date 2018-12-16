using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projet3.Models
{
    public class LecteurViewModel : Lecteur
    {
        public LecteurViewModel() { }
        public LecteurViewModel(Lecteur lecteur)
        {
            this.idLecteur = lecteur.idLecteur;
            this.pseudo = lecteur.pseudo;
            this.email = lecteur.email;
            this.password = lecteur.password;
            this.bloque = lecteur.bloque;
            this.Commentaire = lecteur.Commentaire;
        }

        [Required]
        [Display(Name = "Confirmation de mot de passe")]
        [System.ComponentModel.DataAnnotations.Compare(nameof(password),
            ErrorMessage = "Les deux champs mot de passe ne correspondent pas")]
        public string confirm { get; set; }
    }
}