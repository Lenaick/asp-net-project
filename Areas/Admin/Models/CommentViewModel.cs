using System.ComponentModel.DataAnnotations;

namespace Projet3.Areas.Admin.Models
{
    public class CommentViewModel
    {
        [Required(ErrorMessage = "La réponse doit être renseignée")]
        public string reponse { get; set; }
    }
}