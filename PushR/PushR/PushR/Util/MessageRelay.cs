using Android.Telephony;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PushR.Util
{
    public class MessageRelay
    {
        public void Relay(string Body, string NickName)
        {
            MessagingCenter.Send<MessageRelay,string>(this, Body, NickName);
        }
    }
}
