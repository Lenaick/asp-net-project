using Projet3.Areas.Admin.Validations;
using System.ComponentModel.DataAnnotations;

namespace Projet3.Areas.Admin.Models
{
    public class ArticleViewModelCreate : Projet3.Models.Article
    {
        [Required(ErrorMessage = "Le titre doit être renseigné"),
            Display(Name = "Titre")]
        public new string titre { get; set; }
        [Required(ErrorMessage = "Le contenu doit être renseigné"),
            Display(Name = "Contenu")]
        public new string contenu { get; set; }
        [Display(Name = "Image")]
        public string imageUrl { get; set; }
        [Validations.FileExtensions("jpg,jpeg,png",
             ErrorMessage = "Le fichier ne peut être qu'au format jpg, jpeg ou png")]
        public System.Web.HttpPostedFileBase imageFile { get; set; }
    }

    public class ArticleViewModelEdit : Projet3.Models.Article
    {
        public ArticleViewModelEdit() { }
        public ArticleViewModelEdit(Projet3.Models.Article article)
        {
            this.idArticle = article.idArticle;
            this.idCategorie = article.idCategorie;
            this.titre = article.titre;
            this.contenu = article.contenu;
            this.addedum = article.addedum;
            this.publie = article.publie;
            this.description = article.description;
            this.Categorie = article.Categorie;
            this.Commentaire = article.Commentaire;
            this.image = article.image;
        }
        [Required(ErrorMessage = "Le titre doit être renseigné"),
             Display(Name = "Titre")]
        public new string titre { get; set; }
        [Display(Name = "Image")]
        public string imageUrl { get; set; }
        [Validations.FileExtensions("jpg,jpeg,png",
             ErrorMessage = "Le fichier ne peut être qu'au format jpg, jpeg ou png")]
        public System.Web.HttpPostedFileBase imageFile { get; set; }
    }
}