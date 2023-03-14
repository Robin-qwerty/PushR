using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoadingScreen     
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BottomMenu bottommenu = new BottomMenu(2, 2);
            bottom.Children.Add(bottommenu);

            BusyIndicator busyindicator = new BusyIndicator(1);
            center.Children.Add(busyindicator);
        }
    }
}
