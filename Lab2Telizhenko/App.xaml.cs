using Lab2Telizhenko.Managers;
using Lab2Telizhenko.Models;
using Lab2Telizhenko.Windows;
using System.Windows;

namespace Lab2Telizhenko
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Storage storage = new Storage();
            ContentWindow contentWindow = new ContentWindow();
            NavigationModel navigationModel = new NavigationModel(storage, contentWindow);
            NavigationManager.Instance.Initialize(navigationModel);
            contentWindow.Show();
            navigationModel.Navigate(Modes.Main);
        }
    }
}
