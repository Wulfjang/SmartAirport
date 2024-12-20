using SmartAirport.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using ClosedXML.Excel;
using Microsoft.Win32;


namespace SmartAirport
{
    public partial class FlightManagementForm : Window
    {
        private const string FlightsFilePath = "flights.json";
        private ObservableCollection<Flight> FlightList;

        public FlightManagementForm()
        {
            InitializeComponent();
            LoadFlightData();
            LoadFilterOptions();
        }

        private void LoadFlightData()
        {
            if (File.Exists(FlightsFilePath))
            {
                string json = File.ReadAllText(FlightsFilePath);
                var flights = JsonSerializer.Deserialize<List<Flight>>(json) ?? new List<Flight>();
                FlightList = new ObservableCollection<Flight>(flights);
            }
            else
            {
                FlightList = new ObservableCollection<Flight>();
                SaveFlightData();
            }

            FlightGrid.ItemsSource = FlightList;
        }

        private void SaveFlightData()
        {
            string json = JsonSerializer.Serialize(FlightList.ToList());
            File.WriteAllText(FlightsFilePath, json);
        }

        private void LoadFilterOptions()
        {
            DestinationFilter.ItemsSource = FlightList.Select(f => f.Destination).Distinct().ToList();
            StatusFilter.ItemsSource = FlightList.Select(f => f.Status).Distinct().ToList();
        }

        private void ApplyFilterButton_Click(object sender, RoutedEventArgs e)
        {
            var filteredList = FlightList.Where(f =>
                (DestinationFilter.SelectedItem == null || f.Destination == DestinationFilter.SelectedItem.ToString()) &&
                (StatusFilter.SelectedItem == null || f.Status == StatusFilter.SelectedItem.ToString())).ToList();
            FlightGrid.ItemsSource = filteredList;
        }

        private void ResetFilterButton_Click(object sender, RoutedEventArgs e)
        {
            FlightGrid.ItemsSource = FlightList;
            DestinationFilter.SelectedIndex = -1;
            StatusFilter.SelectedIndex = -1;
        }

        private void AddFlightButton_Click(object sender, RoutedEventArgs e)
        {
            AddFlightForm addFlightForm = new AddFlightForm();
            if (addFlightForm.ShowDialog() == true)
            {
                var newFlight = addFlightForm.NewFlight;
                FlightList.Add(newFlight);
                SaveFlightData();
                LoadFilterOptions();
                MessageBox.Show("Рейс успешно добавлен.");
            }
        }

        private void EditFlightButton_Click(object sender, RoutedEventArgs e)
        {
            if (FlightGrid.SelectedItem is Flight selectedFlight)
            {
                EditFlightForm editFlightForm = new EditFlightForm(selectedFlight);

                if (editFlightForm.ShowDialog() == true) 
                {
                    FlightGrid.Items.Refresh();
                    SaveFlightData();
                    LoadFilterOptions();
                    MessageBox.Show("Рейс успешно обновлён.");
                }
            }
            else
            {
                MessageBox.Show("Выберите рейс для редактирования.");
            }
        }

        private void DeleteFlightButton_Click(object sender, RoutedEventArgs e)
        {
            if (FlightGrid.SelectedItem is Flight selectedFlight)
            {
                FlightList.Remove(selectedFlight);
                SaveFlightData();
                LoadFilterOptions();
                MessageBox.Show("Рейс удалён.");
            }
            else
            {
                MessageBox.Show("Выберите рейс для удаления.");
            }
        }

        private void ExportToExcelButton_Click(object sender, RoutedEventArgs e)
        {
            if (FlightList == null || FlightList.Count == 0)
            {
                MessageBox.Show("Список рейсов пуст. Экспорт невозможен.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Сохранить файл Excel",
                FileName = "Расписание Рейсов.xlsx"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Расписание рейсов");

                        worksheet.Cell(1, 1).Value = "Номер рейса";
                        worksheet.Cell(1, 2).Value = "Пункт назначения";
                        worksheet.Cell(1, 3).Value = "Время отправления";
                        worksheet.Cell(1, 4).Value = "Статус";

                        int currentRow = 2;
                        foreach (var flight in FlightList)
                        {
                            worksheet.Cell(currentRow, 1).Value = flight.FlightNumber;
                            worksheet.Cell(currentRow, 2).Value = flight.Destination;
                            worksheet.Cell(currentRow, 3).Value = flight.DepartureTime;
                            worksheet.Cell(currentRow, 4).Value = flight.Status;
                            currentRow++;
                        }

                        worksheet.Columns().AdjustToContents();

                        workbook.SaveAs(saveFileDialog.FileName);
                    }

                    MessageBox.Show("Данные успешно экспортированы в Excel.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void RefreshDataButton_Click(object sender, RoutedEventArgs e)
        {
            LoadFlightData();
            MessageBox.Show("Данные обновлены.");
        }
    }
}
