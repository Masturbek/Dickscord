using Progect1.Models.LoginModel;
using Progect1.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Progect1.ViewModels.Pages
{
    class LoginPageViewModel:BaseViewModel
    {
        public MainViewModel MainViewModel { get; }
        public LoginModel LoginModel { get; }
        public LoginPageViewModel(MainViewModel mainViewModel)
            => (MainViewModel, LoginCommand, NWCommand, LoginModel) = (mainViewModel, new RelayCommand<object>(_ => Authorize()), new RelayCommand<object>(_ => NWC()),new LoginModel(this, mainViewModel)); // Это аналог простого конструктора, просто в виде кортежа и в одну строку.

        /*
         * Если свойство не используется из кода, то ему не нужно вызывать INotifyPropertyChanged.
         * Другими словами 
         * UI -> Код - без проблем.
         * Код -> UI - будут проблемы, ибо интерфейс не будет знать что свойство изменилось и для этого надо его оповестить через INotifyPropertyChanged.
         * 
         * LoginCommand имеет только get потому, что нам не надо, чтоб его могли изменить.
         */
        public bool Bl = true;
        public string Login { get; set; }
        public string Password { get; set; }

        private string errortext;
        public string ErrorText
        {
            get => errortext;
            set => SetField(ref errortext, value);
        }
        public ICommand LoginCommand { get; }

        public ICommand NWCommand { get; }

        
        private void Authorize()
        {
            //MessageBox.Show()... - это плохо, он стопорит поток, он нарушает MVVM подход, короче, не стоит его использовать для отладки.
            //Debug - это класс, который выводит в окно отладки студии нужную инфомаци. Самое то для отладки!

            Debug.WriteLine($"Авторизация: {Login}:{Password}");

            if (!String.IsNullOrEmpty(Login) & !String.IsNullOrEmpty(Password)) LoginModel.Authorization(new AccountLogin(Login, Password));
            else ErrorTextMessage("Не все поля заполнены");

        }
        private void NWC()
        {
            Statics.MW.Hide();
            Statics.W1.Show();
            //new Window1 { DataContext = new DMainViewModel() }.Show();
        }
        public void ErrorTextMessage(string text) => ErrorText = text;
    }
}
