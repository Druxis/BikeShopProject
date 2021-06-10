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
    public class BuyerManagementService
    {
        private BikeShop2SystemDBContext ctx = new BikeShop2SystemDBContext();

        public List<BuyerDTO> Get(string query)
        {
            List<BuyerDTO> buyerDTOs = new List<BuyerDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                if (query == null)
                {
                    foreach (var item in ctx.Buyers.ToList())
                    {
                        buyerDTOs.Add(new BuyerDTO
                        {
                            Id = item.Id,
                            Name = item.Name,
                            Age = item.Age,
                            Sex = item.Sex,
                            Email = item.Email,
                            Height = item.Height,
                            PhoneNumber = item.PhoneNumber
                        });
                    }
                }
                else
                {
                    foreach (var item in unitOfWork.BuyerRepository.GetByQuery().Where(c => c.Name.Contains(query)).ToList())
                    {
                        buyerDTOs.Add(new BuyerDTO
                        {
                            Id = item.Id,
                            Name = item.Name,
                            Age = item.Age,
                            Sex = item.Sex,
                            Email = item.Email,
                            Height = item.Height,
                            PhoneNumber = item.PhoneNumber
                        });
                    }
                }
                return buyerDTOs;
            }

        }

        public BuyerDTO GetById(int id)
        {
            BuyerDTO buyerDTO = new BuyerDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Buyer buyer = unitOfWork.BuyerRepository.GetByID(id);
                buyerDTO = new BuyerDTO
                {
                    Id = buyer.Id,
                    Name = buyer.Name,
                    Age = buyer.Age,
                    Sex = buyer.Sex,
                    Email = buyer.Email,
                    Height = buyer.Height,
                    PhoneNumber = buyer.PhoneNumber
                };
            }


            return buyerDTO;
        }

        public bool Save(BuyerDTO buyerDTO)
        {
            Buyer Buyer = new Buyer
            {
                Id = buyerDTO.Id,
                Name = buyerDTO.Name,
                Age = buyerDTO.Age,
                Sex = buyerDTO.Sex,
                Email = buyerDTO.Email,
                Height = buyerDTO.Height,
                PhoneNumber = buyerDTO.PhoneNumber

            };
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if (buyerDTO.Id == 0)
                    {
                        unitOfWork.BuyerRepository.Insert(Buyer);
                    }
                    else
                    {
                        unitOfWork.BuyerRepository.Update(Buyer);
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
                Buyer Buyer = ctx.Buyers.Find(id);
                ctx.Buyers.Remove(Buyer);
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