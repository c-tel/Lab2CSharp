using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Telizhenko.Models
{
    public class InvalidEmailException: Exception
    {
        public InvalidEmailException(string invalidEmail): base($"Given email ({invalidEmail}) is invalid!")
        { }
    }
}
