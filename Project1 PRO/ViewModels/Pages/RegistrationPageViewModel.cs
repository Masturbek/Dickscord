using Progect1.Models.AuthModel;
using System.Windows.Input;

namespace Progect1.ViewModels.Pages
{
    class RegistrationPageViewModel
    {
        public MainViewModel MainViewModel { get; }
        public RegistrationModel RegistrationModel { get; }
     
        public RegistrationPageViewModel(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
            RegistrationModel = new RegistrationModel();
            Registration = new RelayCommand<object>(_ => RegistrationModel.Registration(new AccauntRegistration(Login,Password,Email)));
        }
        public ICommand Registration { get; }

        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }


    }
}
