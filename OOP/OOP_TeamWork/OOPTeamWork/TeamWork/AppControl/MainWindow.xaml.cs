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
using AddressBookModel;
using ToDoListModel;
using System.IO;
using System.Collections;
using System.Data;
using DatabaseModel;
using System.Threading;
using System.Windows.Markup;
using System.Globalization;

namespace AppControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // private IMissionFileControler ListOfMissions;
        // "ToDoList.txt"
        public Database<Mission> missionControler;

        public MainWindow()
        {
            InitializeComponent();

            DeletePendingFiles();

            // All below done in the constructor
            this.missionControler = Database<Mission>.GetDatabase("");
            RefreshGeradContent();
        }

        private void DeletePendingFiles()
        {
            var reader = new StreamReader(@"..\..\for_deleting.txt");
            string appDir = ContactsWindow.GetAppDir();

            using (reader)
            {
                var allFiles = reader.ReadToEnd();
                var files = allFiles.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    foreach (var file in files)
                    {
                        File.Delete(System.IO.Path.Combine(appDir, @"Pictures\", file));
                    }
                }
                catch (UnauthorizedAccessException ex) { MessageBox.Show(ex.Message); }
                catch (FileNotFoundException ex) { MessageBox.Show(ex.Message); }
                catch (PathTooLongException ex) { MessageBox.Show(ex.Message); }
                catch (IOException ex) { MessageBox.Show(ex.Message); }
            }

            var writer = new StreamWriter(@"..\..\for_deleting.txt", false);
            using (writer)
            {
                writer.WriteLine();
            }
        }

        private void RefreshGeradContent()
        {
            // Covert ListOfItems to array, because taskGrid create empty row.
            this.taskGrid.ItemsSource = this.missionControler.ListOfItems.ToArray();
            this.taskGrid.Items.Refresh();
        }

        private void ChangeGreadContent(IEnumerable colection)
        {
            this.taskGrid.ItemsSource = colection;
            this.taskGrid.Items.Refresh();
        }

        private void OnShowContactsWindowClick(object sender, RoutedEventArgs e)
        {
            var contacts = new ContactsWindow();
            contacts.Owner = this;
            contacts.ShowDialog();

            this.taskGrid.SelectedItem = null;
            this.Calendar.SelectedDate = null;
        }

        private void OnDeleteTaskClick(object sender, RoutedEventArgs e)
        {
            if (this.taskGrid.SelectedItems.Count > 0)
            {
                var row = this.taskGrid.SelectedItems[0];
                Mission mission = row as Mission;

                this.missionControler.DeleteItem(mission);
                this.RefreshGeradContent();
            }

            this.taskGrid.SelectedItem = null;
            this.Calendar.SelectedDate = null;
        }

        private void OnCreateTaskClick(object sender, RoutedEventArgs e)
        {
            var createTaskWindow = new CreateTaskWindow(DateTime.Now);
            createTaskWindow.Owner = this;
            createTaskWindow.ShowDialog();

            createTaskWindow.Closed += (objectSender, eventArgs) =>
            {
                RefreshGeradContent();
            };

            RefreshGeradContent();
        }

        private void Calendar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedDate = Calendar.SelectedDate.Value;
            var createTaskWindow = new CreateTaskWindow(selectedDate);
            createTaskWindow.Owner = this;
            createTaskWindow.ShowDialog();

            createTaskWindow.Closed += (objectSender, eventArgs) =>
            {
                RefreshGeradContent();
            };

            RefreshGeradContent();
            this.taskGrid.SelectedItem = null;
            this.Calendar.SelectedDate = null;
        }

        private void OnMouseDoubleClickOnTaskGridRow(object sender, MouseButtonEventArgs e)
        {
            // check if the row is double-clicked
            DependencyObject dep = (DependencyObject)e.OriginalSource;
            while ((dep != null) && !(dep is DataGridCell))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }
            if (dep == null) return;

            try
            {
                Mission task = this.taskGrid.SelectedItem as Mission;

                DateTime date = task.Date;

                try
                {
                    date = this.Calendar.SelectedDate.Value;
                }
                catch (Exception)
                {
                    date = task.Date;
                }

                var createTaskWindow = new CreateTaskWindow(date, task);
                createTaskWindow.Owner = this;
                createTaskWindow.ShowDialog();

                createTaskWindow.Closed += (objectSender, eventArgs) =>
                {
                    RefreshGeradContent();
                };

                RefreshGeradContent();
            }
            catch (Exception)
            {
                // throw;
            }

            this.taskGrid.SelectedItem = null;
            this.Calendar.SelectedDate = null;

            //MessageBoxResult result = MessageBox.Show("Hello MessageBox");
        }
    }
}
