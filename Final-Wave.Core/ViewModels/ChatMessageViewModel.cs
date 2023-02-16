using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.Core.ViewModels
{
    public class ChatMessageViewModel
    {
        public class MessageSentViewModel
        {
            public string Title { get; set; }
            public string Text { get; set; }
            public DateTime CreatDate { get; set; }
            public string UserID_Creator { get; set; }
            public string UserID_Reciever { get; set; }
        }
    }
}
