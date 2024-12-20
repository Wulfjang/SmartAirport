using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;

namespace SmartAirport
{
    public partial class MainWindow : Window
    {
        private const string FlightsFilePath = "flights.json";
        private List<Flight> Flights = new List<Flight>();

        public MainWindow()
        {
            InitializeComponent();
            LoadFlightSchedule();
        }

        private void LoadFlightSchedule()
        {
            if (File.Exists(FlightsFilePath))
            {
                string json = File.ReadAllText(FlightsFilePath);
                Flights = JsonSerializer.Deserialize<List<Flight>>(json) ?? new List<Flight>();
            }
            else
            {
                Flights = new List<Flight>();
                SaveFlightSchedule();
            }

            FlightScheduleGrid.ItemsSource = Flights.ToList();
        }

        private void SaveFlightSchedule()
        {
            string json = JsonSerializer.Serialize(Flights);
            File.WriteAllText(FlightsFilePath, json);
        }

        private void AddFlightButton_Click(object sender, RoutedEventArgs e)
        {
            AddFlightForm addFlightForm = new AddFlightForm();
            if (addFlightForm.ShowDialog() == true)
            {
                Flights.Add(addFlightForm.NewFlight);
                SaveFlightSchedule();
                LoadFlightSchedule();
                MessageBox.Show("Рейс успешно добавлен.");
            }
        }

        private void EditFlightButton_Click(object sender, RoutedEventArgs e)
        {
            if (FlightScheduleGrid.SelectedItem is Flight selectedFlight)
            {
                EditFlightForm editFlightForm = new EditFlightForm(selectedFlight);

                if (editFlightForm.ShowDialog() == true)
                {
                    SaveFlightSchedule(); 
                    LoadFlightSchedule(); 
                    MessageBox.Show("Рейс успешно обновлен.");
                }
            }
            else
            {
                MessageBox.Show("Выберите рейс для редактирования.");
            }
        }

        private void DeleteFlightButton_Click(object sender, RoutedEventArgs e)
        {
            if (FlightScheduleGrid.SelectedItem is Flight selectedFlight)
            {
                Flights.Remove(selectedFlight);
                SaveFlightSchedule();
                LoadFlightSchedule();

                MessageBox.Show("Рейс удален.");
            }
            else
            {
                MessageBox.Show("Выберите рейс для удаления.");
            }
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ManageFlightsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            FlightManagementForm flightManagement = new FlightManagementForm();
            flightManagement.Show();
        }

        private void ManageBaggageMenuItem_Click(object sender, RoutedEventArgs e)
        {
            BaggageForm baggageForm = new BaggageForm();
            baggageForm.Show();
        }

        private void ManageSecurityMenuItem_Click(object sender, RoutedEventArgs e)
        {
            SecurityForm securityForm = new SecurityForm();
            securityForm.Show();
        }
    }
}
