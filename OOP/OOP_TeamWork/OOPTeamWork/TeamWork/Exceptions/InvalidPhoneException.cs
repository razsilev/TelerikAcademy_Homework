using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exceptions
{
    public class InvalidPhoneException : AddressBookException
    {
        public InvalidPhoneException()
        {

        }

        public InvalidPhoneException(string message)
            : base(message)
        {

        }
    }
}
