using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string ShipperCity { get; set; }

        [Required]
        public bool IsShipped { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string ProductName { get; set; }

        public DateTime CreateTime { get; set; } = DateTime.Now;
    }

    public class OrderInfo : QueryInfo
    {
        public int ShipState { get; set; }

        public bool? IsShipped
        {
            get
            {
                if (ShipState < 0)
                {
                    return null;
                }
                return Convert.ToBoolean(ShipState);
            }
        }

        public string CustomerName { get; set; }

        public string ShipperCity { get; set; }

        public string PhoneNumber { get; set; }

        public string ProductName { get; set; }

        public List<Order> Orders { get; set; }
    }
}
