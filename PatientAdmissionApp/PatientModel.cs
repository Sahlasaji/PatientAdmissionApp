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
        public DateTime DateofBirth { get; set; }
        public string Address { get; set; }
        public bool Slot { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime ApponitmentDate { get; set; }
        public string ConfirmationStatus { get; set; }
    }
}
