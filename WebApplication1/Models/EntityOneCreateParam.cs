﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class EntityOneCreateParam
    {
        [Required]
        public string Name { get; set; }
    }
}