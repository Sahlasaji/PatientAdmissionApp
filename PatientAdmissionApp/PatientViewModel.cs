using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace PatientAdmissionApp
{
    public class PatientViewModel : BaseViewModel
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
        public ICommand ShowRegistrationCommand { get; set; }
        public ICommand ShowAppointmentCommand { get; set; }
        public ICommand ShowDashboardCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        public PatientViewModel()
        {
            NewPatient = new PatientModel();
            RegisterPatientCommand = new RelayCommand(RegisterPatient);
            SendUpdateCommand = new RelayCommand(SendUpdate);
            ShowRegistrationCommand = new RelayCommand(ShowRegistration);
            ShowAppointmentCommand = new RelayCommand(ShowAppointment);
            ShowDashboardCommand = new RelayCommand(ShowDashboard);
            ExitCommand = new RelayCommand(ExitApplication);
        }

        private void RegisterPatient(object parameter)
        {
            Patients.Add(new PatientModel
            {
                Name = NewPatient.Name,
                Age = NewPatient.Age,
                Dateofbirth = NewPatient.Dateofbirth,
                Address = NewPatient.Address,
                Slot = NewPatient.Slot,
                BookingDate = NewPatient.BookingDate
            });
            NewPatient = new PatientModel();
            MessageBox.Show("Registration Success!!!!");

        }


        private void SendUpdate(object parameter)
        {
            if(SelectedPatient != null)
            {
                SelectedPatient.ConfirmationStatus = NewPatient.ConfirmationStatus;
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

        private void ShowRegistration(object parameter)
        {
            CurrentView = new PatientRegistrationControl() { DataContext = this }; 
        }

        private void ShowAppointment(object parameter)
        {
            CurrentView = new AppointmentControl() { DataContext = this };
        }

        private void ShowDashboard(object parameter)
        {
            CurrentView = new PatientDashboardControl { DataContext = this  };
        }

        private void ExitApplication(object parameter)
        {
            Application.Current.Shutdown();
        }
    }
}