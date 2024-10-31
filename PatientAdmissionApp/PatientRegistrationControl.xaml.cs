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
    /// Interaction logic for PatientRegistrationControl.xaml
    /// </summary>
    public partial class PatientRegistrationControl : UserControl
    {
        public PatientRegistrationControl()
        {
            InitializeComponent();
            this.DataContext = new PatientViewModel();
        }
        private void SlotComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get the DataContext and ensure it's of type PatientViewModel
            if (DataContext is PatientViewModel viewModel)
            {
                if (SlotComboBox.SelectedItem is ComboBoxItem selectedItem)
                {
                    // Get the boolean value from the Tag of the selected item
                    bool isMorning = (bool)selectedItem.Tag;
                    viewModel.NewPatient.Slot = isMorning; // Update the Slot property
                }
            }
        }


    }
}
