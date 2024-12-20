using SmartAirport.Services;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;

namespace SmartAirport
{
    public partial class BaggageForm : Window
    {
        private const string BaggageFilePath = "baggage.json";
        private ObservableCollection<Baggage> BaggageList;

        public BaggageForm()
        {
            InitializeComponent();
            LoadBaggageData();
        }

        private void LoadBaggageData()
        {
            if (File.Exists(BaggageFilePath))
            {
                string json = File.ReadAllText(BaggageFilePath);
                var baggage = JsonSerializer.Deserialize<ObservableCollection<Baggage>>(json);
                BaggageList = baggage ?? new ObservableCollection<Baggage>();
            }
            else
            {
                BaggageList = new ObservableCollection<Baggage>();
                SaveBaggageData();
            }

            BaggageGrid.ItemsSource = BaggageList;
        }

        private void SaveBaggageData()
        {
            string json = JsonSerializer.Serialize(BaggageList);
            File.WriteAllText(BaggageFilePath, json);
        }

        private void AddBaggageButton_Click(object sender, RoutedEventArgs e)
        {
            AddBaggageForm addBaggageForm = new AddBaggageForm();
            if (addBaggageForm.ShowDialog() == true)
            {
                var newBaggage = addBaggageForm.NewBaggage;
                BaggageList.Add(newBaggage);
                SaveBaggageData();
                MessageBox.Show("Багаж успешно добавлен.");
            }
        }

        private void SearchBaggageButton_Click(object sender, RoutedEventArgs e)
        {
            SearchBaggageForm searchBaggageForm = new SearchBaggageForm(BaggageList.ToList());
            if (searchBaggageForm.ShowDialog() == true)
            {
                var foundBaggage = searchBaggageForm.FoundBaggage;
            }
        }

        private void DeleteBaggageButton_Click(object sender, RoutedEventArgs e)
        {
            if (BaggageGrid.SelectedItem is Baggage selectedBaggage)
            {
                BaggageList.Remove(selectedBaggage);
                SaveBaggageData();
                MessageBox.Show("Багаж удален.");
            }
            else
            {
                MessageBox.Show("Выберите багаж для удаления.");
            }
        }
    }
}
