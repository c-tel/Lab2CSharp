using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Telizhenko.Models
{
    public class FutureBirthDateException : Exception
    {
        public FutureBirthDateException(DateTime futureDate) : base($"Given date of birth ({futureDate.ToString("dd-mm-yyyy")}) " +
            "is in future!")
        { }
    }
}
