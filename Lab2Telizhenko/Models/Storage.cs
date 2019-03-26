using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab2Telizhenko.Models
{
    public class Storage
    {
        private readonly JsonPersonRepository _repo;
        public event Action<List<Person>> PeopleChanged;

        public Storage()
        {
            _repo = new JsonPersonRepository("people.json");
        }

        public List<Person> CurrentPeople { get; private set; }

        public void RefreshPeople()
        {
            CurrentPeople = _repo.Get().ToList();
            PeopleChanged?.Invoke(CurrentPeople);
        }

        public void SavePeopleChanges()
        {
            _repo.Put(CurrentPeople);
        }
    }
}
