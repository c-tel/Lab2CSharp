using Lab2Telizhenko.Managers;
using System;

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
            var now = DateTime.Now;
            var age = now.Year - dateOfBirth.Year;
            if (dateOfBirth > now.AddYears(-age))
                --age;
            if (age < 0)
                throw new FutureBirthDateException(dateOfBirth);
            if (age > 135)
                throw new FarBirthDateException(dateOfBirth);
            try
            {
                new System.Net.Mail.MailAddress(email);
            }
            catch
            {
                throw new InvalidEmailException(email);
            }

            var person = new Person(name, surname, email, dateOfBirth);

            _storage.SetUserData(person);
            NavigationManager.Instance.Navigate(Modes.Main);
        }

        private WestZodiac CalculateWest(DateTime date)
        {
            if ((date.Month == 3 && date.Day >= 21) || (date.Month == 4 && date.Day <= 20))
                return WestZodiac.Aries;
            if ((date.Month == 4 && date.Day >= 21) || (date.Month == 5 && date.Day <= 20))
                return WestZodiac.Taurus;
            if ((date.Month == 5 && date.Day >= 21) || (date.Month == 6 && date.Day <= 21))
                return WestZodiac.Gemini;
            if ((date.Month == 6 && date.Day >= 22) || (date.Month == 7 && date.Day <= 22))
                return WestZodiac.Canser;
            if ((date.Month == 7 && date.Day >= 23) || (date.Month == 8 && date.Day <= 23))
                return WestZodiac.Leo;
            if ((date.Month == 8 && date.Day >= 24) || (date.Month == 9 && date.Day <= 23))
                return WestZodiac.Virgo;
            if ((date.Month == 9 && date.Day >= 24) || (date.Month == 10 && date.Day <= 22))
                return WestZodiac.Libra;
            if ((date.Month == 10 && date.Day >= 23) || (date.Month == 11 && date.Day <= 22))
                return WestZodiac.Scorpio;
            if ((date.Month == 11 && date.Day >= 23) || (date.Month == 12 && date.Day <= 21))
                return WestZodiac.Sagittarius;
            if ((date.Month == 12 && date.Day >= 22) || (date.Month == 1 && date.Day <= 20))
                return WestZodiac.Capricorn;
            if ((date.Month == 1 && date.Day >= 21) || (date.Month == 2 && date.Day <= 19))
                return WestZodiac.Aquarius;
            return WestZodiac.Pisces;
        }

        private ChineeseZodiac CalculateChineese(DateTime date)
        {
            var descriptor = (date.Year % 12) - 4;
            if (descriptor < 0)
            {
                descriptor = 12 + descriptor;
            }

            return (ChineeseZodiac)descriptor;
        }
    }
}
