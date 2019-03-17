using System;

namespace Lab2Telizhenko.Models
{
    public class FutureBirthDateException : Exception
    {
        public FutureBirthDateException(DateTime futureDate) : base($"Given date of birth ({futureDate.ToString("dd-mm-yyyy")}) " +
            "is in future!")
        { }
    }
}
