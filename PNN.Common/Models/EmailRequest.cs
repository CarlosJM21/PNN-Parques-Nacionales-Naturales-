﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations

namespace PNN.Common.Models
{
    public class EmailRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
