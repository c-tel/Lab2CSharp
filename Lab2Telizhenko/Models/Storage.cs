using System;

namespace Lab2Telizhenko.Models
{
    public class Storage
    {
        public event Action<Person> PersonChanged;

        public Person CurrentPerson { get; private set; }

        public void SetUserData(Person nextPerson)
        {
            CurrentPerson = nextPerson;
            PersonChanged?.Invoke(CurrentPerson);
        }

    }
}
