using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class BuyerVM
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public byte Age { get; set; }

        public string Sex { get; set; }

        public string Email { get; set; }

        public decimal Height { get; set; }

        public int PhoneNumber { get; set; }

        public BuyerVM() { }

        public BuyerVM(BuyerDTO buyerDTO)
        {
            Id = buyerDTO.Id;
            Name = buyerDTO.Name;
            Age = buyerDTO.Age;
            Sex = buyerDTO.Sex;
            Email = buyerDTO.Email;
            Height = buyerDTO.Height;
            PhoneNumber = buyerDTO.PhoneNumber;
        }
    }
}