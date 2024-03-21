﻿using System;
using System.ComponentModel.DataAnnotations;
namespace TechMaturity.Application.DTOs
{
    public class PracticeDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name is required.")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
         
        
    }
}

