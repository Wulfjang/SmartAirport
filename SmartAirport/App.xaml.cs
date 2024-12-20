using System.Windows;

namespace SmartAirport
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(); // Создаем главную форму

            // Открываем форму логина
            LoginForm loginForm = new LoginForm();
            bool? result = loginForm.ShowDialog(); // Получаем результат из LoginForm

            if (result == true) // Проверяем успешность авторизации
            {
                mainWindow.Show(); // Показываем главную форму
            }
            else
            {
                Current.Shutdown(); // Завершаем приложение, если авторизация не прошла
            }
        }
    }
}