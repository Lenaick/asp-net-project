using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projet3.Areas.Admin.Models
{
    public class ArticleViewModel
    {
        public int idCategorie { get; set; }
        [Required(ErrorMessage = "Le titre doit être renseigné")]
        public string titre { get; set; }
        [Required(ErrorMessage = "Le contenu doit être renseigné")]
        public string contenu { get; set; }
        public string addedum { get; set; }
        public bool publie { get; set; }
        public string image { get; set; }
    }
}