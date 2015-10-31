using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBookModel
{
    interface IContact
    {
        string Name { get; }
        string PhoneNumber { get; set; }
        string Email { get; set; }
        DateTime? Birthday { get; }
    }
}
