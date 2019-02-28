using Lab2Telizhenko.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Telizhenko.Models
{
    public class MainModel
    {
        private Storage _storage;
        public event Action<UserData> UserDataChanged;

        public MainModel(Storage storage)
        {
            _storage = storage;
            _storage.UserDataChanged += OnUserDataChanged;
        }

        private void OnUserDataChanged(UserData userData)
        {
            UserDataChanged?.Invoke(userData);
        }

        internal void Back()
        {
            NavigationManager.Instance.Navigate(Modes.Welcome);
        }
    }
}
