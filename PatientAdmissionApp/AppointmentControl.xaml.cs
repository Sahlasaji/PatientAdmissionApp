using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PatientAdmissionApp
{
    /// <summary>
    /// Interaction logic for AppointmentControl.xaml
    /// </summary>
    public partial class AppointmentControl : UserControl
    {
        public AppointmentControl()
        {
            InitializeComponent();
            //this.DataContext = new PatientViewModel();
            Loaded += AppointmentControl_Loaded;
            Unloaded += UnloadedHandler;
        }

        private void AppointmentControl_Loaded(object sender, RoutedEventArgs e)
        {
            if(DataContext is PatientViewModel viewModel)
            {
                viewModel.AppointmentUpdated += OnAppointmentUpdated;
            }
        }

        private void OnAppointmentUpdated(object sender, EventArgs e)
        {
            MessageBox.Show("Appointment updated");
        }

        private void UnloadedHandler(object sender, RoutedEventArgs e)
        {
            if (DataContext is PatientViewModel viewModel)
            {
                viewModel.AppointmentUpdated -= OnAppointmentUpdated;
            }
        }

    }
}
