using System.Security;
using System.Windows;

namespace SmartAirport
{
    public class SecurityStaff
    {
        public string StaffID { get; set; }
        public string Name { get; set; }    
        public string Surname { get; set; } 
        public string Position { get; set; } 
    }

    public partial class EditStaffForm : Window
    {
        public SecurityStaff EditedStaff { get; private set; }

        public EditStaffForm(SecurityStaff staff)
        {
            InitializeComponent();

            IDTextBox.Text = staff.StaffID;
            NameTextBox.Text = staff.Name;
            SurnameTextBox.Text = staff.Surname;
            PositionTextBox.Text = staff.Position;

            EditedStaff = staff;
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

            // Обновляем данные сотрудника (ID не изменяется)
            EditedStaff.Name = NameTextBox.Text;
            EditedStaff.Surname = SurnameTextBox.Text;
            EditedStaff.Position = PositionTextBox.Text;

            DialogResult = true; // Успешное завершение
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; // Отмена
            Close();
        }
    }
}