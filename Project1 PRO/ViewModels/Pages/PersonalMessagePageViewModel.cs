using Progect1.Controls;
using Progect1.Models.FriendModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Progect1.ViewModels.Pages
{
    public class PersonalMessagePageViewModel : BaseViewModel
    {
        public static DMainViewModel dmainviewmodel { get; set; }
        public PersonalMessagePageViewModel(DMainViewModel Dmainviewmodel)
           => (dmainviewmodel) = (Dmainviewmodel);

        public ObservableCollection<MessageControl> Messages { get; set; } = new ObservableCollection<MessageControl>() { new MessageControl("Nickname1","Date1","Ладно"), new MessageControl("Nickname", "Date", "Ладно"), new MessageControl("Nickname", "Date", "Ладно"), new MessageControl("Nickname", "Date", "Ладно"), new MessageControl("Nickname", "Date", "Ладно"), new MessageControl("Nickname", "Date", "Ладно"), new MessageControl("Nickname", "Date", "Ладно"), new MessageControl("Nickname", "Date", "Ладно"), new MessageControl("Nickname", "Date", "Ладно"), new MessageControl("Nickname", "Date", "Ладно"), new MessageControl("Nickname", "Date", "Ладно"), new MessageControl("Nickname", "Date", "Ладно"), new MessageControl("Nickname", "Date", "Ладно"), new MessageControl("Nickname", "Date", "Ладно"), new MessageControl("Nickname", "Date", "Ладно") };

        private string nickname;
        public string Nickname 
        {
            get { return nickname; }
            set { SetField(ref nickname, value); }
        }
    }
}
