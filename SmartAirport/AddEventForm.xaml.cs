using System;
using System.Windows;
using System.Windows.Controls;

namespace SmartAirport
{
    public partial class AddEventForm : Window
    {
        public SecurityEvent NewEvent { get; private set; }

        public AddEventForm()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EventTextBox.Text) || LevelComboBox.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            NewEvent = new SecurityEvent
            {
                Time = DateTime.Now.ToString("HH:mm:ss"),
                Event = EventTextBox.Text,
                Level = (LevelComboBox.SelectedItem as ComboBoxItem)?.Content.ToString()
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