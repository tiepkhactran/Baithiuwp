using Baithiuwp.Entity;
using Baithiuwp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Baithiuwp.Contact
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ContactPage : Page
    {
       
            private ContactModels contactModel;
            static int Id;

            public ContactPage()
            {
                this.InitializeComponent();
                this.contactModel = new ContactModels();
            }

            private void BtnSubmit_Click(object sender, RoutedEventArgs e)
            {
                Entity.Contacts contact = new Entity.Contacts()
                {
                    Name = name.Text,
                    PhoneNumber = phoneNumber.Text
                };
                contactModel.Insert(contact);
            }
            private void ButtonSearch_OnClick(object sender, RoutedEventArgs e)
            {
                
            }
        }
    }

