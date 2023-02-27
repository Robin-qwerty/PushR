using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using PushR.Models;
using PushR.Views;
using Xamarin.Forms;

namespace PushR.ViewModels
{
    public class ChatPageVM : ViewModelBase
    {
        UserChatModel myModel;
        public ObservableCollection<UserChatModel> UserChatList { get; set; }
        public Command BackCmd { get; private set; }
        public Command SendMessageCmd { get; private set; }

        public ChatPageVM(UserChatModel chatModel)
        {
            UserChatList = new ObservableCollection<UserChatModel>();

            myModel= chatModel;

            BackCmd = new Command(ExecuteBackCmd);
            SendMessageCmd = new Command(ExecuteSendMessageCmd);
        }

        public void ExecuteBackCmd()
        {
            App.Current.MainPage = new UserListPage();
        }

        public void ExecuteSendMessageCmd()
        {
            //send the message
        }

        public async void GetData()
        {
            UserChatList.Clear();

            var result = await Services.Services.UserChat(myModel);
            if (result != null)
            {
                foreach (var user in result)
                {
                    UserChatList.Add(user);
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Failed", "Something went wrong. try again later", "OK");
            }
        }
    }
}
