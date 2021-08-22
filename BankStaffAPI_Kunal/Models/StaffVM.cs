using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankStaffAPI_Kunal.Models
{
    public class StaffVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string EmpCode { get; set; }
        public int DesignationID { get; set; }
        public string DesignationName { get; set; }
    }
}
