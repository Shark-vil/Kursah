using System.Windows;

using Kursah.Common;
using Kursah.View;
using Kursah.ViewModel;

namespace Kursah
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public void Start(object sender, StartupEventArgs e)
        {
            MainWindowV mainWindow = new MainWindowV()
            {

            };
            mainWindow.Show();
        }
    }
}
