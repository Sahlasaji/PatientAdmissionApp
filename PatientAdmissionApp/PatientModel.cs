using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientAdmissionApp
{
    public class PatientModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime Dateofbirth { get; set; } = DateTime.Now;
        public string Address { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.Now;
        public DateTime ApponitmentDate { get; set; } = DateTime.Now;
        public string ConfirmationStatus { get; set; }
        public string Slot { get; set; }
    }
}
