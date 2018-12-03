using System.ComponentModel.DataAnnotations;

namespace Projet3.Areas.Admin.Models
{
    public class ArticleViewModelCreate
    {
        public int idCategorie { get; set; }
        [Required(ErrorMessage = "Le titre doit être renseigné")]
        public string titre { get; set; }
        [Required(ErrorMessage = "Le contenu doit être renseigné")]
        public string contenu { get; set; }
        public bool publie { get; set; }
        public string image { get; set; }
    }

    public class ArticleViewModelEdit
    {
        public int idCategorie { get; set; }
        [Required(ErrorMessage = "Le titre doit être renseigné")]
        public string titre { get; set; }
        public string addedum { get; set; }
        public bool publie { get; set; }
        public string image { get; set; }
    }
}