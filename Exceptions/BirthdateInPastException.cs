using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateProject01.Exceptions
{
    class BirthdateInPastException : ArgumentException
    {
        public int Age { get; }
        public BirthdateInPastException(string message, int age)
        : base(message)
        {
            Age = age;
        }
    }
}
