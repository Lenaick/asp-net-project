﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projet3.Areas.Admin.Models
{
    public class LoginAdminViewModel
    {
        [Required]
        [Display(Name = "Courrier électronique")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }
    }
}
