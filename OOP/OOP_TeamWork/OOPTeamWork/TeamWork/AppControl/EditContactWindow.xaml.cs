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
using AddressBookModel;
using Exceptions;

namespace AppControl
{
    /// <summary>
    /// Interaction logic for EditContactWindow.xaml
    /// </summary>
    public partial class EditContactWindow : Window
    {
        private Contact EditContact { get; set; }

        public EditContactWindow()
        {
            InitializeComponent();
            LoadComponents();
        }

        private void LoadComponents()
        {
            // get the other window elements
            var contactsWindow = Application.Current.Windows.Cast<Window>().
                FirstOrDefault(window => window is ContactsWindow) as ContactsWindow;

            var index = contactsWindow.preview.SelectedIndex;

            try
            {
                EditContact = (Contact)(ContactsWindow.GroupedContacts as ListCollectionView).GetItemAt(index);
            }
            catch (InvalidCastException ex) { MessageBox.Show(ex.Message); }

            this.EditName.Text = EditContact.Name;
            this.EditMobile.Text = EditContact.PhoneNumber;
            this.EditEmail.Text = EditContact.Email;
            if (EditContact.Birthday.HasValue)
            {
                this.EditBirthday.Text = EditContact.Birthday.Value.Date.ToShortDateString();
            }
            this.GroupType.SelectedIndex = (int)EditContact.Group;
        }

        private void OnSaveBtnClick(object sender, RoutedEventArgs e)
        {
            DateTime date;
            bool isDate = DateTime.TryParse(this.EditBirthday.Text.Trim(), out date);

            try
            {
                if (this.EditName.Text.Trim() == "")
                {
                    throw new AddressBookException("Name is mandatory!", new InvalidNameException());
                }
                if (this.EditMobile.Text.Trim() == "")
                {
                    throw new AddressBookException("Mobile phone is mandatory!", new InvalidPhoneException());
                }
                if (this.EditBirthday.Text.Trim() != "")
                {
                    if (!isDate)
                    {
                        throw new InvalidDateException("Enter correct date!");
                    }
                }
                if (this.EditMobile.Text.Trim() != null)
                {
                    string mobile = this.EditMobile.Text.Trim();
                    for (int i = 0; i < mobile.Length; i++)
                    {
                        if (!char.IsDigit(mobile[i]))
                        {
                            throw new InvalidPhoneException("Enter valid mobile number!");
                        }
                    }
                }

                if (this.GroupType.SelectionBoxItem.ToString() == EditContact.Group.ToString())
                {
                    EditContact.Name = this.EditName.Text.Trim();
                    EditContact.Email = this.EditEmail.Text.Trim();
                    EditContact.PhoneNumber = this.EditMobile.Text.Trim();
                    EditContact.Birthday = (date != DateTime.MinValue ? date : (DateTime?)null);

                    (ContactsWindow.GroupedContacts as ListCollectionView).CommitEdit();
                    (ContactsWindow.GroupedContacts as ListCollectionView).Refresh();
                }
                else
                {
                    var contactsWindow = Application.Current.Windows.Cast<Window>().
                    FirstOrDefault(window => window is ContactsWindow) as ContactsWindow;
                    var index = contactsWindow.preview.SelectedIndex;

                    string picture = "";
                    if (EditContact.Picture != @"..\..\Icons\BusinessIcon.png" &&
                        EditContact.Picture != @"..\..\Icons\FamillyIcon.png" &&
                        EditContact.Picture != @"..\..\Icons\FriendIcon.png" &&
                        EditContact.Picture != @"..\..\Icons\OtherIcon.png")
                    {
                        picture = EditContact.Picture;
                    }

                    if (this.GroupType.SelectionBoxItem.ToString() == "Family")
                    {
                        EditContact = new FamillyContact(this.EditName.Text.Trim(), this.EditMobile.Text.Trim(),
                            this.EditEmail.Text.Trim(), date != DateTime.MinValue ? date : (DateTime?)null);
                    }
                    else if (this.GroupType.SelectionBoxItem.ToString() == "Friends")
                    {
                        EditContact = new FriendContact(this.EditName.Text.Trim(), this.EditMobile.Text.Trim(),
                            this.EditEmail.Text.Trim(), date != DateTime.MinValue ? date : (DateTime?)null);
                    }
                    else if (this.GroupType.SelectionBoxItem.ToString() == "Business")
                    {
                        EditContact = new BusinessContact(this.EditName.Text.Trim(), this.EditMobile.Text.Trim(),
                            this.EditEmail.Text.Trim(), date != DateTime.MinValue ? date : (DateTime?)null);
                    }
                    else
                    {
                        EditContact = new OtherContact(this.EditName.Text.Trim(), this.EditMobile.Text.Trim(),
                            this.EditEmail.Text.Trim(), date != DateTime.MinValue ? date : (DateTime?)null);
                    }

                    if (picture != "")
                    {
                        EditContact.Picture = picture;
                    }

                    (ContactsWindow.GroupedContacts as ListCollectionView).RemoveAt(index);
                    (ContactsWindow.GroupedContacts as ListCollectionView).AddNewItem(EditContact);
                    (ContactsWindow.GroupedContacts as ListCollectionView).CommitNew();
                }

                this.EditWindow.Close();
            }
            catch (InvalidDateException ex) { MessageBox.Show(ex.Message); }
            catch (AddressBookException ex) { MessageBox.Show(ex.Message); }
        }
    }
}
