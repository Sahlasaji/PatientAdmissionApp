﻿using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;

namespace PatientAdmissionApp
{
    public class PatientViewModel : BaseViewModel
    {
        // Singleton implementation
        private static PatientViewModel _instance;
        public static PatientViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PatientViewModel();
                }
                return _instance;
            }
        }
        public ObservableCollection<PatientModel> Patients { get; set; } = new ObservableCollection<PatientModel>();

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

        public ICommand RegisterPatientCommand { get; set; }
        public ICommand SendUpdateCommand { get; set; }
        public ICommand ShowRegistrationCommand { get; set; }
        public ICommand ShowAppointmentCommand { get; set; }
        public ICommand ShowDashboardCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        // Private constructor for singleton pattern
        private PatientViewModel()
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
                DateofBirth = NewPatient.DateofBirth,
                Address = NewPatient.Address,
                Slot = NewPatient.Slot,
                BookingDate = NewPatient.BookingDate
            });
            NewPatient = new PatientModel(); // Reset for new entry
            MessageBox.Show("Reached create method!!!!");
        }

        private void SendUpdate(object parameter)
        {
            // Logic to send update
        }

        private void ShowRegistration(object parameter)
        {
            CurrentView = new PatientRegistrationControl { DataContext = this };
        }

        private void ShowAppointment(object parameter)
        {
            CurrentView = new AppointmentControl { DataContext = this };
        }

        private void ShowDashboard(object parameter)
        {
            CurrentView = new PatientDashboardControl { DataContext = this };
        }

        private void ExitApplication(object parameter)
        {
            Application.Current.Shutdown();
        }
    }
}