using Progect1.ViewModels;
using Progect1.ViewModels.Pages;
using Progect1.Views;
using System.Windows;

namespace Progect1
{
    public partial class App : Application
    {
        /* Стартовая точка приложения.
         * Здесь инициализируем главную VM (MainViewModel), задаем DataContext окну (ибо в XAML это плохо!) и показываем само окно.
         * Если нужна некая логика запуска (как раньше Startup.AppStart();), то можно это запускать тут.
         */
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //new MainWindow { DataContext = new MainViewModel() }.Show();
            //Statics.MW.DataContext = new MainViewModel();
            Statics.MW.Show();
            ////mainwindow.DataContext = new MainViewModel();
            ////mainwindow.Show();
        }
    }
}
