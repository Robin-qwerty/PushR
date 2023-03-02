using Plugin.FirebasePushNotification;
using PushR.Views;
using System;
using PushR.Util;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Android.Provider.ContactsContract.CommonDataKinds;

namespace PushR
{
    public partial class App : Application
    {
        public bool HasId;
        public static string UserId;


        public App()
        {
            InitializeComponent();
            CheckId();
        }

        async void CheckId()
        {
            var Id = await SecureStorage.GetAsync("UserId");

            if (string.IsNullOrEmpty(Id))
            {
                MainPage = new RegisterPage();
            }
            else
            {
                MainPage = new UserListPage();
                UserId = Id;
            }

        }
        protected override void OnStart()
        {
            CrossFirebasePushNotification.Current.OnTokenRefresh += async (s, p) =>
            {
                Console.WriteLine($"TOKEN REFRESH: {p.Token}");
                if (HasId)
                {
                    await Services.Services.TokenRefresh(p.Token);
                }
                else
                {
                    await SecureStorage.SetAsync("token", p.Token);
                }
            };

            CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
            {
                try
                {
                    var v = p.Data;

                    var Body = p.Data["body"].ToString();
                    var NickName = p.Data["NickName"].ToString();

                    MessageRelay messageRelay = new MessageRelay();

                    messageRelay.Relay(Body, NickName);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                Services.Services.HandleNotification();
            };
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        

    }
}
