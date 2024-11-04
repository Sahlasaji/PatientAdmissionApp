﻿using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace PatientAdmissionApp
{
     public class PatientViewModel : BaseViewModel, Ipatient
    {
        public event EventHandler ShowRegistrationRequested;
        public event EventHandler AppointmentUpdated;
        public ObservableCollection<PatientModel> Patients { get; set; } = new ObservableCollection<PatientModel>();
        public ObservableCollection<PatientModel> ConfirmedPatients { get; set; } = new ObservableCollection<PatientModel>();

        private PatientModel _newPatient;
        public PatientModel NewPatient
        {
            get { return _newPatient; }
            set { _newPatient = value; OnPropertyChanged(); }
        }

        public ICommand RegisterPatientCommand { get; set; }
        public ICommand ConfirmAppointmentCommand { get; set; }
        public ICommand CancelAppointmentCommand { get; set; }
        public ICommand RequestShowRegistrationCommand { get; set; }



        public PatientViewModel()
        {
            NewPatient = new PatientModel();
            RegisterPatientCommand = new RelayCommand(RegisterPatient);
            ConfirmAppointmentCommand = new RelayCommand(ConfirmAppointment);
            CancelAppointmentCommand = new RelayCommand(CancelAppointment);
            RequestShowRegistrationCommand = new RelayCommand(RequestShowRegistration);

        }

        public void RegisterPatient(object parameter)
        {
            Patients.Add(new PatientModel
            {
                Name = NewPatient.Name,
                Dateofbirth = NewPatient.Dateofbirth,
                Age = DateTime.Now.Year - NewPatient.Dateofbirth.Year,
                Address = NewPatient.Address,
                Slot = NewPatient.Slot,
                BookingDate = NewPatient.BookingDate
               
            });
            NewPatient = new PatientModel();
            MessageBox.Show("Registration Success!!!!");
        }

        public void ConfirmAppointment(object parameter)
        {
            if (parameter is PatientModel patient)
            {
                // Move patient to ConfirmedPatients and remove from Patients
                patient.ConfirmationStatus = "Confirmed";
               

                ConfirmedPatients.Add(patient);
                Patients.Remove(patient);
                AppointmentUpdated?.Invoke(this,EventArgs.Empty);
                MessageBox.Show($"{patient.Name}'s appointment confirmed.");
            }
        }

        public void CancelAppointment(object parameter)
        {
            if (parameter is PatientModel patient)
            {
                // Remove patient from Patients
                Patients.Remove(patient);
                MessageBox.Show($"{patient.Name}'s appointment has been canceled.");
            }
        }

        private void RequestShowRegistration(object parameter)
        {
            ShowRegistrationRequested?.Invoke(this, EventArgs.Empty);
        }


        
    }
}




