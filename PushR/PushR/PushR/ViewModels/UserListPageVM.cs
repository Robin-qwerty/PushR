using PushR.Models;
using Xamarin.Essentials;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using PushR.Views;
using System.Linq;

namespace PushR.ViewModels
{
    public class UserListPageVM : ViewModelBase
    {
        public UserModel myModel;
                public ObservableCollection<UserModel> UserList { get; set; }
        public Command LogoutCmd { get; private set; }
        public UserListPageVM()
        {
            UserList = new ObservableCollection<UserModel>();

            LogoutCmd = new Command(ExecuteLogoutCmd);
        }

        public void ExecuteLogoutCmd()
        {
            bool success = SecureStorage.Remove("UserId");
            App.Current.MainPage = new LoginPage();
        }

        public async void GetData()
        {
            UserList.Clear();

            var result = await Services.Services.AllUsers();

            myModel = new UserModel();

            myModel = (UserModel)result.Where(x => x.Id == App.UserId);
            result.RemoveAll(x => x.Id == App.UserId);

            if (myModel != null) 
            {
                foreach (var user in result)
                {
                    UserList.Add(user);
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Failed", "Something went wrong. try again later", "OK");
            }
        }
    }
}
