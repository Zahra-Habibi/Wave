using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.Core.ViewModels
{
    public class NotationViewModel
    {
        public class RecievedNotationListViewModel
        {
            public int NotationID { get; set; }
            public string NotationTitle { get; set; }
            public string NotationContent { get; set; }
            public DateTime NotationDate { get; set; }
            public NotationCreatorInfo CreatorInfo { get; set; }
            public string UserID_Reciever { get; set; }
        }

        public class SentNotationListViewModel
        {
            public string NotationTitle { get; set; }
            public string NotationContent { get; set; }
            public DateTime NotationDate { get; set; }
            public string UserID_Creator { get; set; }
            public string UserID_Reciever { get; set; }
        }

        public class NotationCreatorInfo
        {
            public string FirstName { get; set; }
            public string Family { get; set; }
            public string FullName { get; set; }
            public string UserID_Creator { get; set; }
        }
        public class NotationSentViewModel
        {
            public string NotationTitle { get; set; }
            public string NotationContent { get; set; }
            public DateTime NotationDate { get; set; }
            public string UserID_Creator { get; set; }
            public string UserID_Reciever { get; set; }
        }
    }
}
