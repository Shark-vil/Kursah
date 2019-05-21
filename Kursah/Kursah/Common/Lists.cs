using Kursah.ViewModel;

namespace Kursah.Common
{
    /// <summary>
    /// Содержит ссылку на контекст приложения
    /// </summary>
    public static class Lists
    {
        public static MainViewVM MainWindow { get; set; }

        public static void SetMV(ref MainViewVM mvVM)
        {
            MainWindow = mvVM;
        }
    }
}
