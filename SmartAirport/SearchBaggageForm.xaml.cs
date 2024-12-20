using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SmartAirport
{
    public partial class SearchBaggageForm : Window
    {
        private readonly List<Baggage> BaggageList;
        public Baggage FoundBaggage { get; private set; }

        public SearchBaggageForm(List<Baggage> baggageList)
        {
            InitializeComponent();
            BaggageList = baggageList;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var flightNumber = FlightNumberTextBox.Text;
            var status = (StatusComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            FoundBaggage = BaggageList.FirstOrDefault(b =>
                (string.IsNullOrWhiteSpace(flightNumber) || b.FlightNumber == flightNumber) &&
                (string.IsNullOrWhiteSpace(status) || b.Status == status));

            if (FoundBaggage != null)
            {
                MessageBox.Show($"Багаж найден: ID: {FoundBaggage.BaggageID}, Рейс: {FoundBaggage.FlightNumber}, Вес: {FoundBaggage.Weight}, Статус: {FoundBaggage.Status}",
                    "Результат поиска", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Багаж не найден.", "Результат поиска", MessageBoxButton.OK, MessageBoxImage.Warning);
                DialogResult = false;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}