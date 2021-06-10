using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Buyer : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public byte Age { get; set; }

        public string Sex { get; set; }

        public string Email { get; set; }

        public decimal Height { get; set; }

        public int PhoneNumber { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
