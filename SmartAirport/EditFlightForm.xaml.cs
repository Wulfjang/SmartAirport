using System.Windows;
using System.Windows.Controls;

namespace SmartAirport
{
    public partial class EditFlightForm : Window
    {
        public Flight EditedFlight { get; private set; }

        public EditFlightForm(Flight flight)
        {
            InitializeComponent();

            FlightNumberTextBox.Text = flight.FlightNumber;
            DestinationTextBox.Text = flight.Destination;
            DepartureTimeTextBox.Text = flight.DepartureTime;
            StatusComboBox.SelectedItem = new ComboBoxItem { Content = flight.Status };
            EditedFlight = flight;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DestinationTextBox.Text) ||
                string.IsNullOrWhiteSpace(DepartureTimeTextBox.Text) ||
                StatusComboBox.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            EditedFlight.Destination = DestinationTextBox.Text;
            EditedFlight.DepartureTime = DepartureTimeTextBox.Text;
            EditedFlight.Status = (StatusComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}