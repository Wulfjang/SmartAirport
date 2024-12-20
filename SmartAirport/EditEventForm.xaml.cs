using System.Windows;
using System.Windows.Controls;

namespace SmartAirport
{
    public partial class EditEventForm : Window
    {
        public SecurityEvent EditedEvent { get; private set; }

        public EditEventForm(SecurityEvent eventToEdit)
        {
            InitializeComponent();

            EventTextBox.Text = eventToEdit.Event;
            foreach (ComboBoxItem item in LevelComboBox.Items)
            {
                if (item.Content.ToString() == eventToEdit.Level)
                {
                    LevelComboBox.SelectedItem = item;
                    break;
                }
            }

            EditedEvent = eventToEdit;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EventTextBox.Text) || LevelComboBox.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            EditedEvent.Event = EventTextBox.Text;
            EditedEvent.Level = (LevelComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

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