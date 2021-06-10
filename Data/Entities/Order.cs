using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Order : BaseEntity
    {

        public int BicycleId { get; set; }
        public virtual Bicycle Bicycle { get; set; }

        public int BuyerId { get; set; }
        public virtual Buyer Buyer { get; set; }

        public string DeliveryService { get; set; }

        [Required]
        public DateTime ArrivalTime { get; set; }

        public string Address { get; set; }

        public decimal FinalPrice { get; set; }
    }
}
