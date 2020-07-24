namespace Progect1.ViewModels.Pages
{
    class RegistrationPageViewModel
    {
        public MainViewModel MainViewModel { get; }
        public RegistrationPageViewModel(MainViewModel mainViewModel) => MainViewModel = mainViewModel;
    }
}
