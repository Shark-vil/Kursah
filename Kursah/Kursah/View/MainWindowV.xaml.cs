using NLog;
using System.Windows;

namespace Kursah.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindowV
    {
        private Logger logger = LogManager.GetCurrentClassLogger();

        public MainWindowV()
        {
            InitializeComponent();

            logger.Info("Application started");
        }
    }
}
