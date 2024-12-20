using System.Windows;
using System.Windows.Controls;

namespace SmartAirport
{
    public partial class AddBaggageForm : Window
    {
        public Baggage NewBaggage { get; private set; }

        public AddBaggageForm()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(BaggageIDTextBox.Text) ||
                string.IsNullOrWhiteSpace(FlightNumberTextBox.Text) ||
                string.IsNullOrWhiteSpace(WeightTextBox.Text) ||
                StatusComboBox.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            NewBaggage = new Baggage
            {
                BaggageID = BaggageIDTextBox.Text,
                FlightNumber = FlightNumberTextBox.Text,
                Weight = WeightTextBox.Text,
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