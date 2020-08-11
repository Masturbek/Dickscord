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
    public class Friend
    {
        public string Name { get; set; }
        public string Tag { get; set; }
        public byte[] photo;

        public DMainViewModel DMainViewModel;
        public ICommand Chat { get; }

        public Friend(string name, string tag,DMainViewModel dmainviewmodel)
        {
            Name = name;
            Tag = tag;
            DMainViewModel = dmainviewmodel;
            Chat = new RelayCommand<object>(_ => dmainviewmodel.ChangePage("PersonalChatPage"));   
        }
    }
}
