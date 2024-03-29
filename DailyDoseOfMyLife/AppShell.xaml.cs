﻿using DailyDoseOfMyLife.View;

namespace DailyDoseOfMyLife
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(View.ProfilePage),typeof(View.ProfilePage));
            Routing.RegisterRoute(nameof(View.HomePage), typeof(View.HomePage));
            Routing.RegisterRoute(nameof(View.CalendarPage),typeof(View.CalendarPage));
            Routing.RegisterRoute(nameof(View.AddEventPage),typeof(View.AddEventPage));
            Routing.RegisterRoute(nameof(View.LoginPage), typeof(View.LoginPage));
        }
    }
}
