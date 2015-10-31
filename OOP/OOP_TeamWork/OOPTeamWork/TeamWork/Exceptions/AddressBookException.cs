using System;

namespace Exceptions
{
    public class AddressBookException : ApplicationException
    {
        public AddressBookException()
        {

        }

        public AddressBookException(string message)
            : base(message)
        {

        }

        public AddressBookException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
