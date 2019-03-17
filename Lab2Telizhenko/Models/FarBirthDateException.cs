using System;

namespace Lab2Telizhenko.Models
{
    public class FarBirthDateException: Exception
    {
        public FarBirthDateException(DateTime farDate) : base($"Given date of birth ({farDate.ToString("dd-mm-yyyy")}) " +
            "is too far to be alive!")
        { }
    }
}
