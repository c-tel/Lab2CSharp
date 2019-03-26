using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Telizhenko.Tools
{
    static class DateTimeExtensions
    {
        public static int YearsAgo(this DateTime dateTime)
        {
            var res = DateTime.Now.Year - dateTime.Year;
            return (dateTime > DateTime.Now.AddYears(-res)) ? res - 1 : res;
        }
    }
}
