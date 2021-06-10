using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Bicycle : BaseEntity
    {
        public string Name { get; set; }
        public DateTime YearOfManufacture { get; set; }
        public string Sex { get; set; }
        public int SerialNumber { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
