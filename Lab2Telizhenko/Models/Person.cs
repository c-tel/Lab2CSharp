using Lab2Telizhenko.Tools;
using Newtonsoft.Json;
using System;

namespace Lab2Telizhenko.Models
{ 
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        // can't set: assuming Email as primary key
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsAdult { get; set; }
        public bool IsBirthday { get; set; }
        public ChineeseZodiac SunSign { get; set; }
        public WestZodiac WestZodiac { get; set; }

        public Person() {  }
        public Person(string name, string surname, string email, DateTime birthDate)
        {
            Name = name;
            Surname = surname;
            Email = email;
            BirthDate = birthDate;
            IsAdult = birthDate.YearsAgo() >= 18;
            SunSign = CalculateChineese(birthDate);
            WestZodiac = CalculateWest(birthDate);
            IsBirthday = DateTime.Now.DayOfYear == birthDate.DayOfYear;
        }

        public Person(string name, string surname, DateTime birthDate)
        {
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
            IsAdult = birthDate.YearsAgo() >= 18;
            SunSign = CalculateChineese(birthDate);
            WestZodiac = CalculateWest(birthDate);
        }

        public Person(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
        }

        private static WestZodiac CalculateWest(DateTime date)
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

        private static ChineeseZodiac CalculateChineese(DateTime date)
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
