using System;

namespace Lab2Telizhenko.Models
{
    public class InvalidEmailException: Exception
    {
        public InvalidEmailException(string invalidEmail): base($"Given email ({invalidEmail}) is invalid!")
        { }
    }
}
