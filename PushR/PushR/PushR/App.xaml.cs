using PushR.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PushR
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            CheckId();
        }

        async void CheckId()
        {
            if (string.IsNullOrEmpty(await SecureStorage.GetAsync("UserId")))
            {
                MainPage = new RegisterPage();
            }
            else
            {
                MainPage = new UserListPage();
            }

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
