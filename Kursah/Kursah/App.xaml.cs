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
            MainWindowV mainWindow = new MainWindowV();
            MainViewVM mvVM = new MainViewVM();
            Lists.SetMV(ref mvVM);
            mainWindow.DataContext = mvVM;
            mainWindow.Closing += (o, arg) => kursahEntities.Close();
            mainWindow.Show();
        }
    }
}
