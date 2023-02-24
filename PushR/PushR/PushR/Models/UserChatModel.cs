using System;
using System.Collections.Generic;
using System.Text;

namespace PushR.Models
{
    public class UserChatModel
    {
        public string Id { get; set; }
        public string From_Id { get; set; }
        public string Message { get; set; }
        public string To_Id { get; set; }
    }
}
