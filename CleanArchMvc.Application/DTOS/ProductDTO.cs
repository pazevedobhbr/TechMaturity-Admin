using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name is required.")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Description is required.")]
        [MinLength(5)]
        [MaxLength(200)]
        public string Description { get; private set; }

        [Required(ErrorMessage = "The Price is required.")]
        [Column(TypeName = "decimal(10,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Price")]
        public decimal Price { get; private set; }

        [Required(ErrorMessage = "The Stock is required.")]
        [Range(1, 9999)]
        [DisplayName("Stock")]
        public int Stock { get; private set; }

        [MaxLength(250)]
        public string Image { get; private set; }

        public Category Category { get; set; }

        [DisplayName("Categories")]
        public int Categoryid { get; set; }
    }
}

