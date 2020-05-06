using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.Entities
{
    class Employee : Users
    {
        public enum DesignationEnum
        {
            Manager,
            Worker,
            Driver,
            Delivery_boy
        }
        public string Name { get; set; }
        public DateTime Joining_date { get; set; }
        public DateTime DOB { get; set; }
        public float Salary { get; set; }
        public int Manager_Id { get; set; }
        public float Bonus { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public int Designation { get; set; }
        public int Branch_id { get; set; }
        
    }
}
