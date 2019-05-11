using System.Windows;

using Kursah.Model;
using Kursah.View;
using Kursah.ViewModel;
using Kursah.Common;

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
                DataContext = new MainViewVM()
            };
            mainWindow.Closing += (o, arg) => kursahEntities.Close();
            mainWindow.Show();
        }
    }
}
