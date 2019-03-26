using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Telizhenko.Models
{
    public class DuplicateEmailException : Exception
    {
        public DuplicateEmailException(string duplicateEmail) : base($"Given email ({duplicateEmail}) is already taken!")
        { }
    }
}
