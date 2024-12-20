using System.Windows;

namespace SmartAirport
{
    public partial class AddStaffForm : Window
    {
        public SecurityStaff NewStaff { get; private set; }

        public AddStaffForm(int nextID)
        {
            InitializeComponent();

            IDTextBox.Text = $"S{nextID:D3}";
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                string.IsNullOrWhiteSpace(SurnameTextBox.Text) ||
                string.IsNullOrWhiteSpace(PositionTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            NewStaff = new SecurityStaff
            {
                StaffID = IDTextBox.Text,
                Name = NameTextBox.Text,
                Surname = SurnameTextBox.Text,
                Position = PositionTextBox.Text
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