using NLog;
using System.Windows;

namespace Kursah.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindowV: Window
    {
        private Logger logger = LogManager.GetCurrentClassLogger();

        public MainWindowV()
        {
            InitializeComponent();

            logger.Info("Application started");
        }
    }
}
