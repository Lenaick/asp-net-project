using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet3.Areas.Admin.Models
{
    public class ArticleViewModel
    {
        public int idCategorie { get; set; }
        public string titre { get; set; }
        public string contenu { get; set; }
        public string addedum { get; set; }
        public bool publie { get; set; }
        public string image { get; set; }
    }
}