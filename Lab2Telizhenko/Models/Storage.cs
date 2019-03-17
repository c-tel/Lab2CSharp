using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
