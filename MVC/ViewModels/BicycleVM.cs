using ApplicationService.DTOs;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class BicycleVM
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Date of release")]
        [DataType(DataType.Date)]
        public DateTime YearOfManufacture { get; set; }
        public string Sex { get; set; }
        public int SerialNumber { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }

        public BicycleVM() { }

        public BicycleVM(BicycleDTO bicycleDTO)
        {
            Id = bicycleDTO.Id;
            Name = bicycleDTO.Name;
            YearOfManufacture = bicycleDTO.YearOfManufacture;
            Sex = bicycleDTO.Sex;
            SerialNumber = bicycleDTO.SerialNumber;
            Type = bicycleDTO.Type;
            Price = bicycleDTO.Price;
        }
    }
}