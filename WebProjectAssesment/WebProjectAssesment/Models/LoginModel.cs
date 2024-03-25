﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebProjectAssesment.Models
{
    public class LoginModel
    {
        [Required]
        public string Username  { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }

    }
}