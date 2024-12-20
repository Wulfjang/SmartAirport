using System.Windows;

namespace SmartAirport
{
    public partial class LoginForm : Window
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordBox.Password;

            if (login == "admin" && password == "1234") // Пример проверки логина
            {
                DialogResult = true; // Авторизация успешна
                Close(); // Закрываем окно логина
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; // Авторизация отменена
            Close(); // Закрываем окно логина
        }
    }
}