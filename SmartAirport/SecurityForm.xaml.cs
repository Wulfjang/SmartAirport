using System;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows;

namespace SmartAirport
{
    public partial class SecurityForm : Window
    {
        private const string EventsFilePath = "security_events.json";
        private ObservableCollection<SecurityEvent> EventLogListData;
        private ObservableCollection<SecurityStaff> SecurityStaffList;


        private void LoadSecurityStaffData()
        {
            if (File.Exists(SecurityStaffFilePath))
            {
                string json = File.ReadAllText(SecurityStaffFilePath);
                var staff = JsonSerializer.Deserialize<ObservableCollection<SecurityStaff>>(json);
                SecurityStaffList = staff ?? new ObservableCollection<SecurityStaff>();
            }
            else
            {
                SecurityStaffList = new ObservableCollection<SecurityStaff>();
            }

            SecurityStaffGrid.ItemsSource = SecurityStaffList;
        }

        public SecurityForm()
        {
            InitializeComponent();
            LoadEventLog();
            LoadSecurityStaffData();
        }

        private void LoadEventLog()
        {
            if (File.Exists(EventsFilePath))
            {
                string json = File.ReadAllText(EventsFilePath);
                var events = JsonSerializer.Deserialize<ObservableCollection<SecurityEvent>>(json);
                EventLogListData = events ?? new ObservableCollection<SecurityEvent>();
            }
            else
            {
                EventLogListData = new ObservableCollection<SecurityEvent>();
                SaveEventLog();
            }

            EventLogList.ItemsSource = EventLogListData;
        }

        private void SaveEventLog()
        {
            string json = JsonSerializer.Serialize(EventLogListData);
            File.WriteAllText(EventsFilePath, json);
        }

        private void AddEventButton_Click(object sender, RoutedEventArgs e)
        {
            AddEventForm addEventForm = new AddEventForm();
            if (addEventForm.ShowDialog() == true)
            {
                var newEvent = addEventForm.NewEvent; 
                EventLogListData.Add(newEvent);
                SaveEventLog();
                MessageBox.Show("Событие успешно добавлено.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void EditEventButton_Click(object sender, RoutedEventArgs e)
        {
            if (EventLogList.SelectedItem is SecurityEvent selectedEvent)
            {
                EditEventForm editEventForm = new EditEventForm(selectedEvent);
                if (editEventForm.ShowDialog() == true)
                {
                    EventLogList.Items.Refresh();
                    SaveEventLog();
                    MessageBox.Show("Событие успешно обновлено.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Выберите событие для редактирования.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void RemoveEventButton_Click(object sender, RoutedEventArgs e)
        {
            if (EventLogList.SelectedItem is SecurityEvent selectedEvent)
            {
                EventLogListData.Remove(selectedEvent);
                SaveEventLog();
                MessageBox.Show("Событие удалено.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Выберите событие для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private const string SecurityStaffFilePath = "security_staff.json";

        private void SaveSecurityStaffData()
        {
            string json = JsonSerializer.Serialize(SecurityStaffList);
            File.WriteAllText(SecurityStaffFilePath, json);
        }

        private void RemoveStaffButton_Click(object sender, RoutedEventArgs e)
        {
            if (SecurityStaffGrid.SelectedItem is SecurityStaff selectedStaff)
            {
                SecurityStaffList.Remove(selectedStaff);

                SaveSecurityStaffData();

                SecurityStaffGrid.Items.Refresh();

                MessageBox.Show($"Сотрудник {selectedStaff.Name} {selectedStaff.Surname} успешно удалён.", "Удаление сотрудника", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Выберите сотрудника для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void AddStaffButton_Click(object sender, RoutedEventArgs e)
        {
            int nextID = SecurityStaffList.Count + 1; // Генерация следующего ID
            AddStaffForm addStaffForm = new AddStaffForm(nextID);

            if (addStaffForm.ShowDialog() == true) // Ожидание закрытия формы
            {
                var newStaff = addStaffForm.NewStaff;
                SecurityStaffList.Add(newStaff); // Добавляем нового сотрудника в список

                SaveSecurityStaffData(); // Сохраняем изменения в файл
                MessageBox.Show("Сотрудник успешно добавлен.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }


        private void EditStaffButton_Click(object sender, RoutedEventArgs e)
        {
            if (SecurityStaffGrid.SelectedItem is SecurityStaff selectedStaff)
            {

                EditStaffForm editStaffForm = new EditStaffForm(selectedStaff);

                if (editStaffForm.ShowDialog() == true) 
                {
                    selectedStaff.Name = editStaffForm.EditedStaff.Name;
                    selectedStaff.Surname = editStaffForm.EditedStaff.Surname;
                    selectedStaff.Position = editStaffForm.EditedStaff.Position;

                    SecurityStaffGrid.Items.Refresh();
                    SaveSecurityStaffData();

                    MessageBox.Show("Данные сотрудника успешно обновлены.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Выберите сотрудника для редактирования.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }

    public class SecurityEvent
    {
        public string Time { get; set; }
        public string Event { get; set; }
        public string Level { get; set; }
    }
}