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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {
            {

                var confirmationControl = new PatientRegistrationControl();


                var mainWindow = Window.GetWindow(this) as MainWindow;
                if (mainWindow != null)
                {
                    mainWindow.MainContent.Content = confirmationControl;
                }
            }
        }

        private void btnAppointment_Click(object sender, RoutedEventArgs e)
        {
            var appointmentControl = new AppointmentControl();
            var appointmentWindow = Window.GetWindow(this) as MainWindow;

            if (appointmentWindow != null)
            {
                appointmentWindow.MainContent.Content = appointmentControl;

            }
        }

        private void btnDashboard_Click(object sender, RoutedEventArgs e)
        {
            var appointmentControl = new PatientDashboardControl();
            var appointmentWindow = Window.GetWindow(this) as MainWindow;

            if (appointmentWindow != null)
            {
                appointmentWindow.MainContent.Content = appointmentControl;

            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
