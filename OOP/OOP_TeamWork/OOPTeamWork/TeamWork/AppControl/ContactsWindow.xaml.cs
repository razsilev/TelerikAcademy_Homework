using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.IO;
using AddressBookModel;
using System.ComponentModel;
using Exceptions;
using System.Reflection;

namespace AppControl
{
    /// <summary>
    /// Interaction logic for ContactsWindow.xaml
    /// </summary>
    public partial class ContactsWindow : Window
    {
        public static ICollectionView GroupedContacts { get; private set; }
        private static List<string> forDeleting = new List<string>();
        private uint counter = 0;

        public ContactsWindow()
        {
            InitializeComponent();
            LoadComponents();
        }

        private void LoadComponents()
        {
            Contact.Contacts.Clear();

            if (File.Exists(@"..\..\contacts.txt"))
            {
                var reader = new StreamReader(@"..\..\contacts.txt");

                try
                {
                    using (reader)
                    {
                        var serializedPersons = reader.ReadToEnd();
                        var persons = serializedPersons.Split(new string[] { Environment.NewLine },
                            StringSplitOptions.RemoveEmptyEntries);
                        foreach (var person in persons)
                        {
                            if (person.StartsWith(ContactGroup.Family.ToString()))
                            {
                                Contact contact = new FamillyContact();
                                Contact.AddContact(contact.Deserialize(person));
                            }
                            else if (person.StartsWith(ContactGroup.Business.ToString()))
                            {
                                Contact contact = new BusinessContact();
                                Contact.AddContact(contact.Deserialize(person));
                            }
                            else if (person.StartsWith(ContactGroup.Friends.ToString()))
                            {
                                Contact contact = new FriendContact();
                                Contact.AddContact(contact.Deserialize(person));
                            }
                            else if (person.StartsWith(ContactGroup.Other.ToString()))
                            {
                                Contact contact = new OtherContact();
                                Contact.AddContact(contact.Deserialize(person));
                            }
                            else continue;
                        }
                    }
                }
                catch (FileLoadException ex) { MessageBox.Show(ex.Message); }
                catch (IOException ex) { MessageBox.Show(ex.Message); }
            }
            else
            {
                try { File.Create(@"..\..\contacts.txt"); }
                catch (PathTooLongException ex) { MessageBox.Show(ex.Message); }
                catch (DirectoryNotFoundException ex) { MessageBox.Show(ex.Message); }
                catch (UnauthorizedAccessException ex) { MessageBox.Show(ex.Message); }
                catch (IOException ex) { MessageBox.Show(ex.Message); }
            }

            GroupedContacts = new ListCollectionView(Contact.Contacts);
            GroupedContacts.GroupDescriptions.Add(new PropertyGroupDescription("Group"));
            GroupedContacts.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
            preview.ItemsSource = GroupedContacts;
        }

        private void OnContactDeleteClick(object sender, RoutedEventArgs e)
        {
            var index = this.preview.SelectedIndex;

            string messageBoxText = string.Format(@"Do you want to delete{0}this contact?", Environment.NewLine);
            string caption = AddressBook.Title;
            MessageBoxButton messageBoxBtn = MessageBoxButton.YesNo;
            MessageBoxImage messageBoxIcon = MessageBoxImage.Question;
            MessageBoxResult messageBoxResult = MessageBox.Show(messageBoxText, caption, messageBoxBtn, messageBoxIcon);

            switch (messageBoxResult)
            {
                case MessageBoxResult.Yes:
                    string picture = ((GroupedContacts as ListCollectionView).GetItemAt(index) as Contact).Picture;
                    forDeleting.Add(picture);

                    (GroupedContacts as ListCollectionView).RemoveAt(index);
                    preview.Items.Refresh();
                    break;
            }
        }

        private void OnAddPictureClick(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "All Picture Files";
            dialog.DefaultExt = ".jpeg";
            dialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png";

            Nullable<bool> result = dialog.ShowDialog();

            if (result == true)
            {
                try
                {
                    string sourceFile = dialog.FileName;
                    string appDir = GetAppDir();

                    counter += 1;
                    StringBuilder destFile = new StringBuilder(counter.ToString() + System.IO.Path.GetExtension(sourceFile));
                    while (File.Exists(System.IO.Path.Combine(appDir, "Pictures\\" + destFile.ToString())))
                    {
                        counter += 1;
                        destFile.Clear();
                        destFile.Append(counter.ToString() + System.IO.Path.GetExtension(sourceFile));
                    }

                    File.Copy(sourceFile, System.IO.Path.Combine(appDir, "Pictures\\" + destFile.ToString()));

                    var index = this.preview.SelectedIndex;
                    Contact contact = (Contact)(GroupedContacts as ListCollectionView).GetItemAt(index);

                    string picture = contact.Picture;
                    if (File.Exists(picture)) { forDeleting.Add(picture); }

                    contact.Picture = System.IO.Path.Combine(appDir, "Pictures\\" + destFile);
                    (GroupedContacts as ListCollectionView).CommitEdit();
                    (GroupedContacts as ListCollectionView).Refresh();
                }
                catch (UnauthorizedAccessException) { MessageBox.Show("To use full functionality logon as administrator!"); }
                catch (FileNotFoundException ex) { MessageBox.Show(ex.Message); }
                catch (PathTooLongException ex) { MessageBox.Show(ex.Message); }
                catch (DirectoryNotFoundException ex) { MessageBox.Show(ex.Message); }
                catch (IOException ex) { MessageBox.Show(ex.Message); }
            }
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

        private static string RemoveEnd(string target, string toRemove)
        {
            if (target.ToLower().EndsWith(toRemove.ToLower()))
            {
                string result = target.Substring(0, target.Length - toRemove.Length);
                return result;
            }

            return target;
        }

        private void OnAddBtnClick(object sender, RoutedEventArgs e)
        {
            DateTime date;
            bool isDate = DateTime.TryParse(this.PersonBirthday.Text, out date);

            try
            {
                if (this.PersonName.Text.Trim() == "")
                {
                    throw new AddressBookException("Name is mandatory!", new InvalidNameException());
                }
                if (this.Mobile.Text.Trim() == "")
                {
                    throw new AddressBookException("Mobile phone is mandatory!", new InvalidPhoneException());
                }
                if (this.PersonBirthday.Text.Trim() != "")
                {
                    if (!isDate)
                    {
                        throw new InvalidDateException("Enter correct date!");
                    }
                }
                if (this.Mobile.Text.Trim() != null)
                {
                    string mobile = this.Mobile.Text.Trim();
                    for (int i = 0; i < mobile.Length; i++)
                    {
                        if (!char.IsDigit(mobile[i]))
                        {
                            throw new InvalidPhoneException("Enter valid mobile number!");
                        }
                    }
                }

                if (GroupType.SelectionBoxItem.ToString() == "Family")
                {
                    Contact newContact = new FamillyContact(this.PersonName.Text.Trim(), this.Mobile.Text.Trim(),
                        this.PersonEmail.Text.Trim(), date == DateTime.MinValue ? (DateTime?)null : date);
                    (GroupedContacts as ListCollectionView).AddNewItem(newContact);
                }
                else if (GroupType.SelectionBoxItem.ToString() == "Friends")
                {
                    Contact newContact = new FriendContact(this.PersonName.Text.Trim(), this.Mobile.Text.Trim(),
                        this.PersonEmail.Text.Trim(), date == DateTime.MinValue ? (DateTime?)null : date);
                    (GroupedContacts as ListCollectionView).AddNewItem(newContact);
                }
                else if (GroupType.SelectionBoxItem.ToString() == "Business")
                {
                    Contact newContact = new BusinessContact(this.PersonName.Text.Trim(), this.Mobile.Text.Trim(),
                        this.PersonEmail.Text.Trim(), date == DateTime.MinValue ? (DateTime?)null : date);
                    (GroupedContacts as ListCollectionView).AddNewItem(newContact);
                }
                else
                {
                    Contact newContact = new OtherContact(this.PersonName.Text.Trim(), this.Mobile.Text.Trim(),
                        this.PersonEmail.Text.Trim(), date == DateTime.MinValue ? (DateTime?)null : date);
                    (GroupedContacts as ListCollectionView).AddNewItem(newContact);
                }

                (GroupedContacts as ListCollectionView).CommitNew();

                this.PersonName.Text = "";
                this.PersonEmail.Text = "";
                this.PersonBirthday.Text = "";
                this.Mobile.Text = "";
            }
            catch (InvalidDateException ex) { MessageBox.Show(ex.Message); }
            catch (AddressBookException ex) { MessageBox.Show(ex.Message); }
        }

        private void OnContactsWindowClosed(object sender, EventArgs e)
        {
            var writeContacts = new StreamWriter(@"..\..\contacts.txt", false);
            var writeFilesForDeleting = new StreamWriter(@"..\..\for_deleting.txt", true);

            try
            {
                using (writeContacts)
                using (writeFilesForDeleting)
                {
                    foreach (Contact contact in GroupedContacts)
                    {
                        writeContacts.WriteLine(contact.Serialize());
                    }

                    foreach (string file in forDeleting)
                    {
                        writeFilesForDeleting.WriteLine(System.IO.Path.GetFileName(file));
                    }
                    forDeleting.Clear();
                }
            }
            catch (PathTooLongException ex) { MessageBox.Show(ex.Message); }
            catch (FileNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (DirectoryNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (UnauthorizedAccessException ex) { MessageBox.Show(ex.Message); }
            catch (IOException ex) { MessageBox.Show(ex.Message); }
        }

        private void OnDelKeyboardKey(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                var index = this.preview.SelectedIndex;

                string messageBoxText = string.Format(@"Do you want to delete{0}this contact?", Environment.NewLine);
                string caption = AddressBook.Title;
                MessageBoxButton messageBoxBtn = MessageBoxButton.YesNo;
                MessageBoxImage messageBoxIcon = MessageBoxImage.Question;
                MessageBoxResult messageBoxResult = MessageBox.Show(messageBoxText, caption, messageBoxBtn, messageBoxIcon);

                switch (messageBoxResult)
                {
                    case MessageBoxResult.Yes:
                        string picture = ((GroupedContacts as ListCollectionView).GetItemAt(index) as Contact).Picture;
                        forDeleting.Add(picture);

                        (GroupedContacts as ListCollectionView).RemoveAt(index);
                        preview.Items.Refresh();
                        break;
                }
            }
        }

        private void OnContactEditClick(object sender, RoutedEventArgs e)
        {
            var editContact = new EditContactWindow();
            editContact.Owner = this;
            editContact.ShowDialog();
        }

        private void RowDoubleClick(object sender, RoutedEventArgs e)
        {
            var row = (DataGridRow)sender;
            row.DetailsVisibility = row.DetailsVisibility == Visibility.Collapsed ?
                Visibility.Visible : Visibility.Collapsed;
        }

        private void preview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void OnSendMailClick(object sender, RoutedEventArgs e)
        {
            var index = this.preview.SelectedIndex;
            Contact contact = (Contact)(GroupedContacts as ListCollectionView).GetItemAt(index);

            if (contact.Email != "")
            {
                // Open the "HKLM\SOFTWARE\Clients\Mail" key.
                Microsoft.Win32.RegistryKey mailKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Clients\Mail");

                // The default mail application is stored in the default value of that key.
                string defaultMailApp = (string)mailKey.GetValue(null);

                if (defaultMailApp != null && defaultMailApp.Length > 0)
                {
                    string fileName = "mailto:" + contact.Email;
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(fileName));
                }
                else MessageBox.Show("Install Outlook first!");
            }
            else
            {
                MessageBox.Show(this, "Enter e-mail in contact form first!");
            }
        }
    }
}
