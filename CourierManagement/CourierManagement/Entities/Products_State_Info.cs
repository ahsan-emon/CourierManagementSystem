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
            Not_yet_Received,
            Received,
            Shipped,
            On_the_way,
            Sent_to_destination,
            Released
        }
        public int Product_State { get; set; }
        public DateTime Release_Date { get; set; }
        public int Product_Id { get; set; }
    }
}
