using PushR.Models;
using PushR.ViewModels;
using Xamarin.Forms;
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
			InitializeComponent();
            viewModel = new ChatPageVM(model);
            viewModel.GetData();

            BindingContext = viewModel;
        }
	}
}