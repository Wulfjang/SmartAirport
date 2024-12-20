using System.Windows;
using System.Windows.Controls;

namespace SmartAirport
{
    public partial class AddFlightForm : Window
    {
        public Flight NewFlight { get; private set; }

        public AddFlightForm()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FlightNumberTextBox.Text) ||
                string.IsNullOrWhiteSpace(DestinationTextBox.Text) ||
                string.IsNullOrWhiteSpace(DepartureTimeTextBox.Text) ||
                StatusComboBox.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            NewFlight = new Flight
            {
                FlightNumber = FlightNumberTextBox.Text,
                Destination = DestinationTextBox.Text,
                DepartureTime = DepartureTimeTextBox.Text,
                Status = (StatusComboBox.SelectedItem as ComboBoxItem)?.Content.ToString()
            };

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