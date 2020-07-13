using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwarePC.Data.Model
{
    public class Order : IdentityBase
    {
        public Order()
        {
            this.OrderDetail = new HashSet<OrderDetail>();
        }
        
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public float TotalPrice { get; set; }
        public int OrderNumber { get; set; }
        public int ItemCount { get; set; }

        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
