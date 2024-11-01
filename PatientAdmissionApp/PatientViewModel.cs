using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace PatientAdmissionApp
{
    public class PatientViewModel : BaseViewModel, Ipatient
    {
        public event EventHandler AppointmentUpdated;
        public ObservableCollection<PatientModel> Patients { get; set; } = new ObservableCollection<PatientModel>();
        public ObservableCollection<PatientModel> ConfirmedPatients { get; set; } = new ObservableCollection<PatientModel>();


        private PatientModel _newPatient;
        public PatientModel NewPatient
        {
            get { return _newPatient; }
            set { _newPatient = value; OnPropertyChanged(); }
        }

        private PatientModel _selectedPatient;
        public PatientModel SelectedPatient
        {
            get { return _selectedPatient; }
            set { _selectedPatient = value; OnPropertyChanged(); }
        }
        private bool _selectedSlot;
        public bool SelectedSlot
        {
            get { return _selectedSlot; }
            set { _selectedSlot = value; OnPropertyChanged(nameof(SelectedSlot)); }
        }

        public ICommand RegisterPatientCommand { get; set;}
        public ICommand SendUpdateCommand { get; set; }
        

        public PatientViewModel()
        {
            NewPatient = new PatientModel();
            RegisterPatientCommand = new RelayCommand(RegisterPatient);
            SendUpdateCommand = new RelayCommand(SendUpdate);
        }

        public void RegisterPatient(object parameter)
        {
            Patients.Add(new PatientModel
            {
                Name = NewPatient.Name,
                Dateofbirth = NewPatient.Dateofbirth,
                Age = NewPatient.Age,
                Address = NewPatient.Address,
                Slot = NewPatient.Slot,
                BookingDate = NewPatient.BookingDate
            });
            NewPatient = new PatientModel();
            MessageBox.Show("Registration Success!!!!");

        }


        public void SendUpdate(object parameter)
        {
            if(SelectedPatient != null)
            {
                SelectedPatient.ConfirmationStatus = NewPatient.ConfirmationStatus;
                SelectedPatient.AppointmentDate = NewPatient.AppointmentDate;
                OnAppointmentUpdated();
                if(!ConfirmedPatients.Contains(SelectedPatient))
                {
                    ConfirmedPatients.Add(SelectedPatient);
                }
            }
            else
            {
                MessageBox.Show("Please select a Patient");
            }
            
        }

        protected virtual void OnAppointmentUpdated()
        {
            AppointmentUpdated?.Invoke(this, EventArgs.Empty);
        }
    }
}