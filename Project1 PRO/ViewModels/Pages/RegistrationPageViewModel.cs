using Progect1.Models.AuthModel;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using System;
using System.Media;
using System.Linq;
using System.Windows;

namespace Progect1.ViewModels.Pages
{
     class RegistrationPageViewModel : BaseViewModel
    {
        public MainViewModel MainViewModel { get; }
        public RegistrationModel RegistrationModel { get; }
     
        public RegistrationPageViewModel(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
            RegistrationModel = new RegistrationModel(this);

            //Registration = new RelayCommand<object>(_ => Debug.WriteLine(RegistrationModel.Registration(new AccauntRegistration(Login, Password, Email), ErrorEmailText, ErrorLoginText, ErrorPasswordText)));
            Registration = new RelayCommand<object>(_ => Reg());
        }
        public ICommand Registration { get; }

        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        private string errorlogintext;
        public string ErrorLoginText
        {
            get => errorlogintext;
            set => SetField(ref errorlogintext, value);
        }

        private string errorpasswordtext;
        public string ErrorPasswordText
        {
            get => errorpasswordtext;
            set => SetField(ref errorpasswordtext, value);
        }

        private string erroremailtext;
        public string ErrorEmailText
        {
            get => erroremailtext;
            set => SetField(ref erroremailtext, value);
        }

        public async Task Reg()
        {
            await Task.Factory.StartNew(async () =>
            {
                await Application.Current.Dispatcher.InvokeAsync(() =>
                {
                    string EmailCorrect = Validation.EmailValidation(Email);
                    string LoginCorrect = Validation.LoginValidation(Login);
                    string PasswordCorrect = Validation.PasswordValidation(Password);
                    if (EmailCorrect != "CorrectEmail")
                        ErrorEmailText = EmailCorrect;
                    else ErrorEmailText = null;
                    if (LoginCorrect != "CorrectLogin")
                        ErrorLoginText = LoginCorrect;
                    else ErrorLoginText = null;
                    if (PasswordCorrect != "CorrectPassword")
                        ErrorPasswordText = PasswordCorrect;
                    else ErrorPasswordText = null;
                    if (EmailCorrect == "CorrectEmail" & LoginCorrect == "CorrectLogin" & PasswordCorrect == "CorrectPassword")
                        RegistrationModel.Registration(new AccauntRegistration(Login, Password, Email));
                });
            });
            //string EmailCorrect = Validation.EmailValidation(Email);
            //string LoginCorrect = Validation.LoginValidation(Login);
            //string PasswordCorrect = Validation.PasswordValidation(Password);
            //if (EmailCorrect != "CorrectEmail")
            //    ErrorEmailText = EmailCorrect;
            //else ErrorEmailText = null;
            //if (LoginCorrect != "CorrectLogin")
            //    ErrorLoginText = LoginCorrect;
            //else ErrorLoginText = null;
            //if (PasswordCorrect != "CorrectPassword")
            //    ErrorPasswordText = PasswordCorrect;
            //else ErrorPasswordText = null;
            //if (EmailCorrect == "CorrectEmail" & LoginCorrect == "CorrectLogin" & PasswordCorrect == "CorrectPassword")
            //    RegistrationModel.Registration(new AccauntRegistration(Login,Password,Email));
        }
    }
}
