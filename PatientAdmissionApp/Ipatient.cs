using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientAdmissionApp
{
    public interface Ipatient
    {
        ObservableCollection<PatientModel> Patients { get; }
       void RegisterPatient(object parameter);
      




    }
}
