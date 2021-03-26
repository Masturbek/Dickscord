using Progect1.Models.FriendModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Progect1.ViewModels.Pages
{
    public class FriendListViewModel
    {
        public DMainViewModel dmainviewmodel { get; }
        

        public FriendListViewModel(DMainViewModel Dmainviewmodel,PersonalMessagePageViewModel personalMessagePageViewModel)
        {
            dmainviewmodel = Dmainviewmodel;   
            Statics.H(dmainviewmodel, personalMessagePageViewModel);
        }



        public static ObservableCollection<Profile> FriendList { get; set; } = new ObservableCollection<Profile>();
        public static ObservableCollection<Profile> OnlineFriendList { get; set; } = new ObservableCollection<Profile>();
        public static ObservableCollection<Profile> RequestList { get; set; } = new ObservableCollection<Profile>();
        public static ObservableCollection<Profile> RequestWaitList { get; set; } = new ObservableCollection<Profile>();
    }
}
