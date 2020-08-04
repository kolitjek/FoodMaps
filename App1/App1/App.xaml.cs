﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.View
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Device.SetFlags(new string[] { "Expander_Experimental" });

            MainPage = new NavigationPage(new MainPage());

            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#6d9eeb");

            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
