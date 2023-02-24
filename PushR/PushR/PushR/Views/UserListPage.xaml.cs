using PushR.Models;
using PushR.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PushR.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserListPage : ContentPage
    {
        public UserListPageVM viewModel;
        public UserListPage()
        {
            InitializeComponent();
            viewModel = new UserListPageVM();
            BindingContext = viewModel;
            viewModel.GetData();
        }

        public async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selected = e.SelectedItem as UserModel;

            UserChatModel chatModel = new UserChatModel
            {
                From_Id = await SecureStorage.GetAsync("UserId"),
                To_Id = selected.Id
            };

            App.Current.MainPage = new ChatPage(chatModel);
        }
    }
}