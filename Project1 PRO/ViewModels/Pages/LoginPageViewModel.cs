using System.Diagnostics;
using System.Windows.Input;

namespace Progect1.ViewModels.Pages
{
    class LoginPageViewModel
    {
        public MainViewModel MainViewModel { get; }
        public LoginPageViewModel(MainViewModel mainViewModel)
            => (MainViewModel, LoginCommand) = (mainViewModel, new RelayCommand<object>(_ => Authorize())); // Это аналог простого конструктора, просто в виде кортежа и в одну строку.


        /*
         * Если свойство не используется из кода, то ему не нужно вызывать INotifyPropertyChanged.
         * Другими словами 
         * UI -> Код - без проблем.
         * Код -> UI - будут проблемы, ибо интерфейс не будет знать что свойство изменилось и для этого надо его оповестить через INotifyPropertyChanged.
         * 
         * LoginCommand имеет только get потому, что нам не надо, чтоб его могли изменить.
         */

        public string Login { get; set; }
        public string Password { get; set; }
        public ICommand LoginCommand { get; }

        private void Authorize()
        {
            //MessageBox.Show()... - это плохо, он стопорит поток, он нарушает MVVM подход, короче, не стоит его использовать для отладки.
            //Debug - это класс, который выводит в окно отладки студии нужную инфомаци. Самое то для отладки!
            Debug.WriteLine($"Авторизация: {Login}:{Password}");
        }
    }
}
