using Lab2Telizhenko.Managers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab2Telizhenko.Models
{
    public class MainModel
    {
        private Storage _storage;
        public event Action<List<Person>> PeopleChanged;

        public MainModel(Storage storage)
        {
            _storage = storage;
            _storage.PeopleChanged += OnPeopleChanged;
        }

        private void OnPeopleChanged(List<Person> people)
        {
            PeopleChanged?.Invoke(people);
        }
        
        public void RefreshPeople()
        {
            _storage.RefreshPeople();
        }

        public List<Person> CurrentPeople()
        {
            return _storage.CurrentPeople;
        }

        public void Back()
        {
            NavigationManager.Instance.Navigate(Modes.Welcome);
        }

        public void Remove(Person toRemove)
        {
            _storage.CurrentPeople.RemoveAll(p => p.Email == toRemove.Email);
            _storage.SavePeopleChanges();
            _storage.RefreshPeople();
        }

        public void Edit(Person toEdit, string nextName, string nextSurname)
        {
            var ind = _storage.CurrentPeople.FindIndex(p => p.Email == toEdit.Email);
            _storage.CurrentPeople[ind].Name = nextName;
            _storage.CurrentPeople[ind].Surname = nextSurname;
            _storage.SavePeopleChanges();
            _storage.RefreshPeople();
        }

        public void AddPerson()
        {
            NavigationManager.Instance.Navigate(Modes.Welcome);
        }
    }
}
