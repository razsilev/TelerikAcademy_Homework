using MongoDbData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MongoDbChatWpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isLoged;
        private string username;
        private ChatContext context;

        public MainWindow()
        {
            InitializeComponent();

            this.isLoged = false;
            this.context = new ChatContext();
            //PrintMessages();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = tbUserName.Text;

            username = username.Trim();

            if (username.Length > 2)
            {
                isLoged = true;

                labelLogedUser.Content = "Loged user:\n" + username;
                this.username = username;

                PrintMessages();
            }
            else
            {
                System.Windows.MessageBox.Show("Username length mast be longer then 2 symbols after Trim()!");
            }

            tbUserName.Text = string.Empty;
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            if (this.isLoged)
            {
                // get messages from mongoDb
                PrintMessages();
            }
        }


        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if (this.isLoged && this.tbInput.Text.Trim() != string.Empty)
            {
                // get messages from mongoDb
                var message = new Message()
                                {
                                    user = new User() { Username = this.username },
                                    Text = this.tbInput.Text,
                                    Date = DateTime.Now
                                };

                this.context.AddMessage(message);
                
                PrintMessages();
            }
        }

        private void PrintMessages()
        {
            var newMessages = context.GetAllMessages();

            var messagesString = new StringBuilder();

            for (int i = 0; i < newMessages.Count; i++)
            {
                messagesString.Append(newMessages[i].ToString());
            }

            tbMessages.Text = messagesString.ToString();
        }
    }
}
