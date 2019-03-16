using System;

namespace DateProject01.Exceptions
{
    class BirthdateInFutureException : ArgumentException
    {
        public int Age { get;  }
        public BirthdateInFutureException(string message, int age)
        : base(message)
        {
            Age = age;
        }
    }
}
