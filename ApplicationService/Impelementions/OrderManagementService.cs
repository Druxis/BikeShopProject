using ApplicationService.DTOs;
using Data.Context;
using Data.Entities;
using Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Implementations
{
    public class OrderManagementService
    {
        private BikeShop2SystemDBContext ctx = new BikeShop2SystemDBContext();

        public List<OrderDTO> Get(string query)
        {
            List<OrderDTO> orderDTOs = new List<OrderDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())

                if (query == null)
                {
                    foreach (var item in unitOfWork.OrderRepository.Get())
                    {
                        orderDTOs.Add(new OrderDTO
                        {
                            Id = item.Id,
                            BicycleId = item.BicycleId,
                            Bicycle = new BicycleDTO
                            {
                                Id = item.BicycleId,
                                Name = item.Bicycle.Name,
                                YearOfManufacture = item.Bicycle.YearOfManufacture,
                                Sex = item.Bicycle.Sex,
                                SerialNumber = item.Bicycle.SerialNumber,
                                Type = item.Bicycle.Type
                            },
                            BuyerId = item.BuyerId,
                            Buyer = new BuyerDTO
                            {
                                Id = item.BuyerId,
                                Name = item.Buyer.Name,
                                Age = item.Buyer.Age,
                                Sex = item.Buyer.Sex,
                                Email = item.Buyer.Email,
                                Height = item.Buyer.Height,
                                PhoneNumber = item.Buyer.PhoneNumber
                            },
                            DeliveryService = item.DeliveryService,
                            ArrivalTime = item.ArrivalTime,
                            Address = item.Address,
                            FinalPrice = item.FinalPrice
                        });
                    }
                }
                else
                {
                    foreach (var item in unitOfWork.OrderRepository.GetByQuery().Where(c => c.DeliveryService.Contains(query)).ToList())
                    {
                        orderDTOs.Add(new OrderDTO
                        {
                            Id = item.Id,
                            BicycleId = item.BicycleId,
                            Bicycle = new BicycleDTO
                            {
                                Id = item.BicycleId,
                                Name = item.Bicycle.Name,
                                YearOfManufacture = item.Bicycle.YearOfManufacture,
                                Sex = item.Bicycle.Sex,
                                SerialNumber = item.Bicycle.SerialNumber,
                                Type = item.Bicycle.Type,
                                Price = item.Bicycle.Price
                            },
                            BuyerId = item.BuyerId,
                            Buyer = new BuyerDTO
                            {
                                Id = item.BuyerId,
                                Name = item.Buyer.Name,
                                Age = item.Buyer.Age,
                                Sex = item.Buyer.Sex,
                                Email = item.Buyer.Email,
                                Height = item.Buyer.Height,
                                PhoneNumber = item.Buyer.PhoneNumber
                            },
                            DeliveryService = item.DeliveryService,
                            ArrivalTime = item.ArrivalTime,
                            Address = item.Address,
                            FinalPrice = item.FinalPrice
                        });
                    }

                }

            return orderDTOs;
        }

        public OrderDTO GetById(int id)
        {
            Order item = ctx.Orders.Find(id);

            OrderDTO orderDTO = new OrderDTO
            {
                Id = item.Id,
                BicycleId = item.BicycleId,
                Bicycle = new BicycleDTO
                {
                    Id = item.BicycleId,
                    Name = item.Bicycle.Name,
                    YearOfManufacture = item.Bicycle.YearOfManufacture,
                    Sex = item.Bicycle.Sex,
                    SerialNumber = item.Bicycle.SerialNumber,
                    Type = item.Bicycle.Type,
                    Price = item.Bicycle.Price
                },
                BuyerId = item.BuyerId,
                Buyer = new BuyerDTO
                {
                    Id = item.BuyerId,
                    Name = item.Buyer.Name,
                    Age = item.Buyer.Age,
                    Sex = item.Buyer.Sex,
                    Email = item.Buyer.Email,
                    Height = item.Buyer.Height,
                    PhoneNumber = item.Buyer.PhoneNumber
                },
                DeliveryService = item.DeliveryService,
                ArrivalTime = item.ArrivalTime,
                Address = item.Address,
                FinalPrice = item.FinalPrice
            };
            return orderDTO;
        }

        public bool Save(OrderDTO orderDTO)
        {
            if (orderDTO.Bicycle == null || orderDTO.BicycleId == 0)
            {
                return false;
            }

            else if (orderDTO.Buyer == null || orderDTO.BuyerId == 0)
            {
                return false;
            }

            Order Order = new Order
            {
                Id = orderDTO.Id,
                BicycleId = orderDTO.BicycleId,
                BuyerId = orderDTO.BuyerId,
                DeliveryService = orderDTO.DeliveryService,
                ArrivalTime = orderDTO.ArrivalTime,
                Address = orderDTO.Address,
                FinalPrice = orderDTO.FinalPrice
            };
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if (orderDTO.Id == 0)
                    {
                        unitOfWork.OrderRepository.Insert(Order);
                    }
                    else
                    {
                        unitOfWork.OrderRepository.Update(Order);
                    }

                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                Order Order = ctx.Orders.Find(id);
                ctx.Orders.Remove(Order);
                ctx.SaveChanges();
                return true;
            }

            catch
            {
                return false;
            }
        }
    }
}