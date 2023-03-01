using PushR.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PushR.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        LoginPageVM viewModel;
        public LoginPage()
        {
            InitializeComponent();
            viewModel = new LoginPageVM();
            BindingContext = viewModel;
        }
    }
}