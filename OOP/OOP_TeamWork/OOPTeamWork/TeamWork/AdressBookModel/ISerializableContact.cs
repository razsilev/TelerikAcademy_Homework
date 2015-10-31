using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBookModel
{
    interface ISerializableContact
    {
        string Serialize();
        Contact Deserialize(string person);
    }
}
