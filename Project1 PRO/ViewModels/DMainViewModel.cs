using Progect1.Models.FriendModel;
using Progect1.ViewModels.Pages;
using Progect1.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Progect1.ViewModels
{
    public class DMainViewModel : BaseViewModel
    {
        public DMainViewModel()
        {
            MinimizeCommand = new RelayCommand<Window>(Minimize);
            CloseCommand = new RelayCommand<Window>(Close);
            ChangePageCommand = new RelayCommand<string>(ChangePage);

            PersonalMessagePageViewModel = new PersonalMessagePageViewModel(this);

            FriendListViewModel = new FriendListViewModel(this, PersonalMessagePageViewModel);
           

              FriendList = new RelayCommand<object>(_ => ToFriendListPage());

            //CurrentPage = LoginPageViewModel;
        }

        public FriendListViewModel FriendListViewModel { get;}
        public PersonalMessagePageViewModel PersonalMessagePageViewModel { get; }
        public ICommand MinimizeCommand { get; }
        public ICommand CloseCommand { get; }
        public ICommand FriendList { get; }

        private void Close(Window window) => window.Close();
        private void Minimize(Window window) => window.WindowState = WindowState.Minimized;
        private void ToFriendListPage() => Debug.WriteLine("123");

        private object currentPage;
        public object CurrentPage
        {
            get => currentPage;
            set => SetField(ref currentPage, value);
        }
        public ICommand ChangePageCommand { get; }
        public void ChangePage(string page)
        {
            switch (page)
            {
                case "FriendList":
                    SetPage(FriendListViewModel);
                    break;
                case "PersonalChatPage":
                    SetPage(PersonalMessagePageViewModel);
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
