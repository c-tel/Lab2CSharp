using Lab2Telizhenko.Managers;
using Lab2Telizhenko.Tools;
using System;
using System.Linq;

namespace Lab2Telizhenko.Models
{
    public class WelcomeModel
    {
        private Storage _storage;

        public WelcomeModel(Storage storage)
        {
            _storage = storage;
        }

        public void SubmitForm(DateTime dateOfBirth, string name, string surname, string email)
        {
            ValidateData(dateOfBirth, email);
            var person = new Person(name, surname, email, dateOfBirth);
            _storage.CurrentPeople.Add(person);
            _storage.SavePeopleChanges();
            _storage.RefreshPeople();
            NavigationManager.Instance.Navigate(Modes.Main);
        }

        private void ValidateEmail(string email)
        {
            try
            {
                var _ = new System.Net.Mail.MailAddress(email);
            }
            catch
            {
                throw new InvalidEmailException(email);
            }
            if (_storage.CurrentPeople.Any(p => p.Email == email))
                throw new DuplicateEmailException(email);
        }

        private void ValidateData(DateTime dateOfBirth, string email)
        {
            var age = dateOfBirth.YearsAgo();
            if (age < 0)
                throw new FutureBirthDateException(dateOfBirth);
            if (age > 135)
                throw new FarBirthDateException(dateOfBirth);
            ValidateEmail(email);
        }
    }
}
