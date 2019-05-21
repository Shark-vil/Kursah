using Kursah.Model;
using Kursah.ViewModel;
using Kursah.View;

namespace Kursah.Common
{
    public static class Lists
    {
        public static MainViewVM MainWindow { get; set; }

        public static void SetMV(ref MainViewVM mvVM)
        {
            MainWindow = mvVM;
        }
    }
}
