using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstApi
{
    public class AppointmentSlot
    {
        public int PatientID { get; set; }
        public string Time { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Reason { get; set; }
        public string Notes { get; set; }
    }
}
