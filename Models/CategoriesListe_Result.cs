//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Projet3.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class CategoriesListe_Result
    {
        public int idCategorie { get; set; }
        [Display(Name = "Libellé")]
        public string libelle { get; set; }
        [Display(Name = "Nombre d'articles associés")]
        public Nullable<int> nbArticles { get; set; }
    }
}
