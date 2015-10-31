using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exceptions
{
    public class InvalidNameException : AddressBookException
    {
        public InvalidNameException()
        {

        }

        public InvalidNameException(string message)
            : base(message)
        {

        }
    }
}
