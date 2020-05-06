using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.Entities
{
    class Products_State_Info : BaseEntity
    {
        public enum ProductStateEnum
        {
            Received,
            Shipped,

        }
        public int Product_State { get; set; }
        public DateTime Release_Date { get; set; }
    }
}
