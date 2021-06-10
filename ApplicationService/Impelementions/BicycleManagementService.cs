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
    public class BicycleManagementService
    {
        private BikeShop2SystemDBContext ctx = new BikeShop2SystemDBContext();

        public List<BicycleDTO> Get(string query)
        {
            List<BicycleDTO> bicycleDTOs = new List<BicycleDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                if (query == null)
                {
                    foreach (var item in unitOfWork.BicycleRepository.Get())
                    {
                        bicycleDTOs.Add(new BicycleDTO
                        {
                            Id = item.Id,
                            Name = item.Name,
                            YearOfManufacture = item.YearOfManufacture,
                            Sex = item.Sex,
                            SerialNumber = item.SerialNumber,
                            Type = item.Type,
                            Price = item.Price
                        });
                    }
                }
                else
                {
                    foreach (var item in unitOfWork.BicycleRepository.GetByQuery().Where(c => c.Name.Contains(query)).ToList())
                    {
                        bicycleDTOs.Add(new BicycleDTO
                        {
                            Id = item.Id,
                            Name = item.Name,
                            YearOfManufacture = item.YearOfManufacture,
                            Sex = item.Sex,
                            SerialNumber = item.SerialNumber,
                            Type = item.Type,
                            Price = item.Price
                        });
                    }
                }
            }
            return bicycleDTOs;
        }

        public BicycleDTO GetById(int id)
        {

            BicycleDTO bicycleDTO = new BicycleDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Bicycle bicycle = unitOfWork.BicycleRepository.GetByID(id);

                bicycleDTO = new BicycleDTO
                {
                    Id = bicycle.Id,
                    Name = bicycle.Name,
                    YearOfManufacture = bicycle.YearOfManufacture,
                    Sex = bicycle.Sex,
                    SerialNumber = bicycle.SerialNumber,
                    Type = bicycle.Type,
                    Price = bicycle.Price
                };

            }

            return bicycleDTO;
        }

        public bool Save(BicycleDTO bicycleDTO)
        {
            Bicycle Bicycle = new Bicycle()
            {
                Id = bicycleDTO.Id,
                Name = bicycleDTO.Name,
                YearOfManufacture = bicycleDTO.YearOfManufacture,
                Sex = bicycleDTO.Sex,
                SerialNumber = bicycleDTO.SerialNumber,
                Type = bicycleDTO.Type,
                Price = bicycleDTO.Price
            };
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if (bicycleDTO.Id == 0)
                    {
                        unitOfWork.BicycleRepository.Insert(Bicycle);
                    }
                    else
                    {
                        unitOfWork.BicycleRepository.Update(Bicycle);
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
                Bicycle Bicycle = ctx.Bicycles.Find(id);
                ctx.Bicycles.Remove(Bicycle);
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