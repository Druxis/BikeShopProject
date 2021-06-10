using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class OrderVM
    {
        public int Id { get; set; }

        public int BicycleId { get; set; }
        public virtual BicycleDTO Bicycle { get; set; }

        public int BuyerId { get; set; }
        public virtual BuyerDTO Buyer { get; set; }

        public string DeliveryService { get; set; }

        [Required]
        public DateTime ArrivalTime { get; set; }

        public string Address { get; set; }

        public decimal FinalPrice { get; set; }

        public OrderVM() { }

        public OrderVM(OrderDTO orderDTO)
        {
            Id = orderDTO.Id;
            BicycleId = orderDTO.BicycleId;
            Bicycle = new BicycleDTO
            {
                Id = orderDTO.BicycleId,
                Name = orderDTO.Bicycle.Name,
                YearOfManufacture = orderDTO.Bicycle.YearOfManufacture,
                Sex = orderDTO.Bicycle.Sex,
                SerialNumber = orderDTO.Bicycle.SerialNumber,
                Type = orderDTO.Bicycle.Type
            };
            BuyerId = orderDTO.BuyerId;
            Buyer = new BuyerDTO
            {
                Id = orderDTO.BuyerId,
                Name = orderDTO.Buyer.Name,
                Age = orderDTO.Buyer.Age,
                Sex = orderDTO.Buyer.Sex,
                Email = orderDTO.Buyer.Email,
                Height = orderDTO.Buyer.Height,
                PhoneNumber = orderDTO.Buyer.PhoneNumber
            };
            DeliveryService = orderDTO.DeliveryService;
            ArrivalTime = orderDTO.ArrivalTime;
            Address = orderDTO.Address;
            FinalPrice = orderDTO.FinalPrice;
        }
    }
}