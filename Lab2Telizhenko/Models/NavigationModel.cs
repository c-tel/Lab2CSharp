using Lab2Telizhenko.Views;
using Lab2Telizhenko.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Telizhenko.Models
{
    public enum Modes
    {
        Welcome, Main
    }

    public class NavigationModel
    {
        private Storage _storage;
        private ContentWindow _contentWindow;
        private WelcomeView _welcomeView;
        private MainView _mainView;

        public NavigationModel(Storage storage, ContentWindow contentWindow)
        {
            _storage = storage;
            _contentWindow = contentWindow;
            _welcomeView = new WelcomeView(storage);
            _mainView = new MainView(storage);
        }

        public void Navigate(Modes mode)
        {
            switch (mode)
            {
                case Modes.Welcome:
                    _contentWindow.ContentControl.Content = _welcomeView;
                    break;
                case Modes.Main:
                    _contentWindow.ContentControl.Content = _mainView;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode));
            }
        }
    }
}