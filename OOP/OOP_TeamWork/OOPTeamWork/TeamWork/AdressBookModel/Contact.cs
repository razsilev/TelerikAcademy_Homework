using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace AddressBookModel
{
    public abstract class Contact : IContact, ISerializableContact
    {
        private static List<Contact> contacts = new List<Contact>();
        protected StringBuilder contact = new StringBuilder();

        public static List<Contact> Contacts
        {
            get { return contacts; }
        }
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Icon { get; set; }
        public ContactGroup Group { get; set; }
        public string Picture { get; set; }

        public Contact() { }

        public Contact(string name, string telNumber, string email, DateTime? birthday)
        {
            this.Name = name;
            this.PhoneNumber = telNumber;
            this.Email = email;
            this.Birthday = birthday;
        }

        public virtual string Serialize()
        {
            contact.Append(this.Name + "|");
            contact.Append(this.PhoneNumber + "|");
            contact.Append(this.Email + "|");
            if (this.Birthday.HasValue)
            {
                DateTime date = this.Birthday.Value;
                contact.Append(date.Day + "." + date.Month + "." + date.Year + "|");
            }
            else contact.Append("|");

            if (this.Picture != @"..\..\Icons\FamillyIcon.png" &&
                this.Picture != @"..\..\Icons\BusinessIcon.png" &&
                this.Picture != @"..\..\Icons\FriendIcon.png" &&
                this.Picture != @"..\..\Icons\OtherIcon.png")
            {
                string appDir = GetAppDir();
                contact.Append(Path.GetFileName(this.Picture));
            }
            else contact.Append(this.Picture);

            return this.contact.ToString();
        }

        public abstract Contact Deserialize(string person);

        public static void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }

        public static string GetAppDir()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string assemblyDir = assembly.CodeBase;
            assemblyDir = assemblyDir.Replace("file:///", "");
            assemblyDir = System.IO.Path.GetDirectoryName(assemblyDir);

            //string appDir = RemoveEnd(assemblyDir, @"\bin\debug");
            //appDir = RemoveEnd(appDir, @"\bin\release");
            return assemblyDir;
        }
    }
}
