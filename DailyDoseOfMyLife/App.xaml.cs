﻿using DailyDoseOfMyLife.View;

namespace DailyDoseOfMyLife
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

           MainPage = new AppShell();
        }
    }
}
