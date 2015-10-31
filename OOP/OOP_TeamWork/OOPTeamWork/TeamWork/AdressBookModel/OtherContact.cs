using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AddressBookModel
{
    public class OtherContact : Contact
    {
        public OtherContact() { }

        public OtherContact(string name, string telNumber, string email, DateTime? birthday)
            : base(name, telNumber, email, birthday)
        {
            this.Icon = @"..\..\Icons\OtherIcon.png";
            if (this.Picture == null)
            {
                this.Picture = @"..\..\Icons\OtherIcon.png";
            }
            this.Group = ContactGroup.Other;
        }

        public override string Serialize()
        {
            base.Serialize();
            this.contact.Insert(0, ContactGroup.Other.ToString() + "|");

            return this.contact.ToString();
        }

        public override Contact Deserialize(string person)
        {
            DateTime date;
            var personInfo = person.Split(new char[] { '|' });
            DateTime.TryParse(personInfo[4], out date);
            Contact contact = new OtherContact(personInfo[1], personInfo[2], personInfo[3],
                date == DateTime.MinValue ? (DateTime?)null : date);

            string appDir = GetAppDir();
            if (File.Exists(Path.Combine(appDir, "Pictures\\" + personInfo[5])))
            {
                contact.Picture = Path.Combine(appDir, "Pictures\\" + personInfo[5]);
            }
            else contact.Picture = @"..\..\Icons\OtherIcon.png";

            return contact;
        }
    }
}
