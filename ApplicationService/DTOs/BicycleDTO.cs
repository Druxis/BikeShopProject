using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class BicycleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime YearOfManufacture { get; set; }
        public string Sex { get; set; }
        public int SerialNumber { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
    }
}
