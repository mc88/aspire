using System;
using System.Collections.Generic;
using System.Windows;
using WPFAspire.BusinessInterfaces.Models;

namespace WPFAspire.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WebApiCommunication webApiCommunication = new WebApiCommunication();
        private IList<ContactViewModel> contacts = new List<ContactViewModel>();

        public MainWindow()
        {
            InitializeComponent();


            var searchModel = new SearchContactModel()
            {
                FirstName = string.Empty,
                LastName = string.Empty
            };

            //contacts = webApiCommunication.SearchContacts(searchModel).Result;
            lvContacts.ItemsSource = contacts;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var searchModel = new SearchContactModel()
            {
                FirstName = tbSearchFirstName.Text,
                LastName = tbSearchLastName.Text
            };

            contacts = webApiCommunication.SearchContacts(searchModel).Result;
        }

        private void btnAddPhone_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddEmail_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            DateTime birthDate;

            AddContactModel contact = new AddContactModel()
            {
                FisrtName = tbFirstName.Text,
                LastName = tbLastName.Text
            };

            if (!string.IsNullOrEmpty(tbDateOfBirth.Text))
            {
                bool parseResult = DateTime.TryParse(tbDateOfBirth.Text, out birthDate);

                if (!parseResult)
                {
                    MessageBox.Show("Invalid birth date");
                    return;
                }

                contact.DateOfBirth = birthDate;
            }
            else
            {
                contact.DateOfBirth = null;
            }

            await webApiCommunication.AddContact(contact);
        }
    }
}
