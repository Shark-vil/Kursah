﻿using Kursah.Common;

namespace Kursah.ViewModel
{
    public class MainViewVM
    {
        public MainViewVM()
        {
            DataBase.Start();

            Stage_1_1_Context = new Stage_1_1VM();
        }

        public Stage_1_1VM Stage_1_1_Context { get; set; }
    }
}
