using PushR.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PushR.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        RegisterPageVM viewModel;
        public RegisterPage()
        {
            InitializeComponent();
            viewModel = new RegisterPageVM();
            BindingContext = viewModel;
        }
    }
}