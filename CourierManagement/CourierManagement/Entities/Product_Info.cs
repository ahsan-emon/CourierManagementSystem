using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.Entities
{
    class Product_Info : BaseEntity
    {
        public enum ProductTypeEnum
        {
            Large,
            Medium,
            Small
        }
        public int ProductType { get; set; }
        public int Customer_id { get; set; }
        public int Reciving_B_id { get; set; }
        public int Sending_B_id { get; set; }
        public float Delivery_charge { get; set; }
        public int Manager_id { get; set; }
    }
}
