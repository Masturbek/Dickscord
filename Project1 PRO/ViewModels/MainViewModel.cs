using Progect1.ViewModels.Pages;
using Progect1.Views;
using Progect1.Views.Pages;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace Progect1.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            /*
             * Заметьте, каждая команда инициализируется только один раз, 
             * а не как было в вашем случае, через get постоянная инициализация.
             */
            MinimizeCommand = new RelayCommand<Window>(Minimize);
            CloseCommand = new RelayCommand<Window>(Close);
            NormalizeCommand = new RelayCommand<Window>(Normalize);
            ChangePageCommand = new RelayCommand<string>(ChangePage);


            LoginPageViewModel = new LoginPageViewModel(this);
            RegistrationPageViewModel = new RegistrationPageViewModel(this);

            CurrentPage = LoginPageViewModel;
        }
        #region Закрыть/Свернуть
        public ICommand MinimizeCommand { get; }
        public ICommand CloseCommand { get; }
        public ICommand NormalizeCommand { get; }


        private void Close(Window window) => window.Close();
        private void Minimize(Window window) => window.WindowState = WindowState.Minimized;
        private void Normalize(Window window) => window.WindowState = WindowState.Normal;
        #endregion


        #region Страницы
        private LoginPageViewModel LoginPageViewModel { get; }
        private RegistrationPageViewModel RegistrationPageViewModel { get; }

        private object currentPage;
        public object CurrentPage
        {
            get => currentPage;
            set => SetField(ref currentPage, value);
        }
        #endregion

        public ICommand ChangePageCommand { get; }

        public void ChangePage(string page)
        {
            switch (page)
            {
                case "Login":
                    SetPage(LoginPageViewModel);
                    break;
                case "Registration":
                    SetPage(RegistrationPageViewModel);
                    break;
            }
        }

        public void SetPage(object page)
        {
            if (CurrentPage != page)
            {
                CurrentPage = page;
                Debug.WriteLine($"Страница изменена на {page.GetType().Name}");
            }    
        }
    }
}
