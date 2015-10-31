using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exceptions
{
    public class InvalidDateException : AddressBookException
    {
        public InvalidDateException()
        {

        }

        public InvalidDateException(string message)
            : base(message)
        {

        }
    }
}
