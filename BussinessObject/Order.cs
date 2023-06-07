using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PaymentMethodId { get; set; }
        public string Code { get; set; }
        public int State { get; set; }
        public DateTime CreatedAt { get; set; }
        public double TotalPrice { get; set; }
        public PaymentStatus PaymentStatus { get; set; }

        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<OrderStatusDetail> OrderStatusDetails { get; set; }
    }
}
