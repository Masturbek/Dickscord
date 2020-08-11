using Progect1.Models.FriendModel;
using System;
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
       

        public FriendListViewModel(DMainViewModel Dmainviewmodel)
        {
            dmainviewmodel = Dmainviewmodel;   
            Statics.H(dmainviewmodel);
        }

      

        public static ObservableCollection<Friend> MTTF { get; set; } = new ObservableCollection<Friend>
        {
                
        };

    }
}
