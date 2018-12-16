using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projet3.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Le sujet doit être renseigné"),
             Display(Name = "Sujet")]
        public string sujet { get; set; }

        [Required(ErrorMessage = "Le message doit être renseigné"),
             Display(Name = "Message")]
        public string message { get; set; }
    }
}