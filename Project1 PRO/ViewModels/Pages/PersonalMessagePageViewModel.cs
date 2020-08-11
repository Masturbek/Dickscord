using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progect1.ViewModels.Pages
{
    public class PersonalMessagePageViewModel
    {
        public DMainViewModel dmainviewmodel { get; }
        public PersonalMessagePageViewModel(DMainViewModel Dmainviewmodel)
           => (dmainviewmodel) = (Dmainviewmodel);
    }
}
