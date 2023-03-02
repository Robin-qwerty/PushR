using PushR.Models;
using PushR.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;
using static Android.App.Assist.AssistStructure;

namespace PushR.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChatPage : ContentPage
	{
        ChatPageVM viewModel;

        public ChatPage(UserChatModel model)
		{
            Xamarin.Forms.Application.Current.On<Xamarin.Forms.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
            InitializeComponent();
            viewModel = new ChatPageVM(model);
            viewModel.GetData();

            BindingContext = viewModel;


            MessagingCenter.Subscribe<ChatPage, string>(this, "Hi", async (sender, arg) =>
            {
                await DisplayAlert("Message received", "arg=" + arg, "OK");
            });

        }
	}
}