using Progect1.Models.FriendModel;
using Progect1.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progect1.ViewModels.Pages
{
    public class Statics
    {
        public static MainWindow MW = new MainWindow { DataContext = new MainViewModel() };
        public static Window1 W1 = new Window1 { DataContext = new DMainViewModel() };
     
        public static void H(DMainViewModel dmainviewmodel)
        {
            FriendListViewModel.MTTF.Add(new Friend("Friend 2", "#2222", dmainviewmodel));
            FriendListViewModel.MTTF.Add(new Friend("Friend 2", "#2222", dmainviewmodel));
            FriendListViewModel.MTTF.Add(new Friend("Friend 2", "#2222", dmainviewmodel));
            FriendListViewModel.MTTF.Add(new Friend("Friend 2", "#2222", dmainviewmodel));
            FriendListViewModel.MTTF.Add(new Friend("Friend 2", "#2222", dmainviewmodel));
            FriendListViewModel.MTTF.Add(new Friend("Friend 2", "#2222", dmainviewmodel));
        }
        public Statics ()
        {
           
        }

    }
}
