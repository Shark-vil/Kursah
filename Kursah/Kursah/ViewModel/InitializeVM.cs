using System.Collections.Generic;

using Kursah.Model;

namespace Kursah.ViewModel
{
    public class InitializeVM
    {
        public static List<GoodsCounts> Counts { get; set; }

        static InitializeVM()
        {
            RefreshList();
        }

        public InitializeVM()
        {
            RefreshList();
        }

        public static void RefreshList()
        {
            List<GoodsCounts> tmpList = new List<GoodsCounts>();
            foreach (Goods good in kursahEntities.Instane.Goods)
            {
                tmpList.Add(new GoodsCounts(good, 0));
            }
            Counts = tmpList;
        }
    }
}
