using System.Windows;

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
            this.DataContext = PatientViewModel.Instance;

        }

        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {
            

                var confirmationControl = new PatientRegistrationControl();


                var mainWindow = Window.GetWindow(this) as MainWindow;
                if (mainWindow != null)
                {
                    mainWindow.MainContent.Content = confirmationControl;
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
            var patientDashboardControl = new PatientDashboardControl();
            var patientDashboard = Window.GetWindow(this) as MainWindow;

            if (patientDashboard != null)
            {
                patientDashboard.MainContent.Content = patientDashboardControl;

            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
