using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoEat.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string Producer { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        [Display(Name = "Cena jednostkowa")]
        [Range(1, 10000)]
        public double ListPrice { get; set; }

        [Required]
        [Display(Name = "Cena za zakup 2 sztuk")]
        [Range(1, 10000)]
        public double Price2 { get; set; }

        [Required]
        [Display(Name = "Cena za zakup 10 sztuk")]
        [Range(1, 10000)]
        public double Price10 { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name = "Kategoria")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }

        [Required]
        [Display(Name ="Typ okładki")]
        public int CoverTypeId { get; set; }
        [ValidateNever]
        public CoverType CoverType { get; set; }


    }
}
