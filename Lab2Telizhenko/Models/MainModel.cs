using Lab2Telizhenko.Managers;
using System;

namespace Lab2Telizhenko.Models
{
    public class MainModel
    {
        private Storage _storage;
        public event Action<Person> PersonChanged;

        public MainModel(Storage storage)
        {
            _storage = storage;
            _storage.PersonChanged += OnPersonChanged;
        }

        private void OnPersonChanged(Person person)
        {
            PersonChanged?.Invoke(person);
        }

        internal void Back()
        {
            NavigationManager.Instance.Navigate(Modes.Welcome);
        }
    }
}
