using Progect1.ViewModels;
using Progect1.ViewModels.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Progect1.Models.FriendModel
{
    public class FriendListModel
    {

    }
    public class Profile
    {
        public string Name { get; set; }
        public string Tag { get; set; }
        public byte[] photo;

        public DMainViewModel DMainViewModel;
        PersonalMessagePageViewModel personalmessagePageViewModel;
        public ICommand Chat { get; }

        public Profile(string name, string tag, DMainViewModel dmainviewmodel, PersonalMessagePageViewModel personalMessagePageViewModel)
        {
            Name = name;
            Tag = tag;
            DMainViewModel = dmainviewmodel;
            personalmessagePageViewModel = personalMessagePageViewModel;
            Chat = new RelayCommand<object>(_ => OpenLS());
            void OpenLS()
                {
                personalmessagePageViewModel.Nickname = Name;
                dmainviewmodel.ChangePage("PersonalChatPage");
            }
        }
    }
}
