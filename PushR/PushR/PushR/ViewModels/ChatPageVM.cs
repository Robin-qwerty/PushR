using System.Collections.ObjectModel;
using PushR.Models;
using PushR.Views;
using Xamarin.Forms;

namespace PushR.ViewModels
{
    public class ChatPageVM : ViewModelBase
    {
        UserChatModel myModel;
        public ObservableCollection<UserChatModel> UserChatList { get; set; }


        public ChatPageVM(UserChatModel chatModel)
        {
            UserChatList = new ObservableCollection<UserChatModel>();

            myModel= chatModel;
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
        }
    }
}
