﻿namespace RedMangoAPI.Models.Dto
{
    using System.ComponentModel.DataAnnotations;

    public class MenuItemUpdateDTO
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string SpecialTag { get; set; }
        public string Category { get; set; }
        [Range(1, int.MaxValue)]
        public double Price { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}