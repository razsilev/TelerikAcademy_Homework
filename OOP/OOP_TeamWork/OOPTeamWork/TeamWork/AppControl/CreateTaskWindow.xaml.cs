using DatabaseModel;
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
using ToDoListModel;

namespace AppControl
{
    /// <summary>
    /// Interaction logic for CreateSingleTask.xaml
    /// </summary>
    public partial class CreateTaskWindow : Window
    {
        private DateTime taskDate;
        private Mission editMission;
        // private IMissionFileControler missionFileControler;
        private DatabaseModel.Database<Mission> missionFileControler = Database<Mission>.GetDatabase("");
        //private DatabaseModel.Database<Mission> ListOfMissions = new DatabaseModel.Database<Mission>("ToDoList.txt");
        // Instead the above we need to call the parent window
        public CreateTaskWindow(DateTime taskDate, Mission editMission = null)
        {
            InitializeComponent();

            this.taskDate = taskDate;
            this.editMission = editMission;
            // this.missionFileControler = new MissionFileControler();
            List<PriorityLevel> priorityLevels = new List<PriorityLevel>();

            priorityLevels.Add(PriorityLevel.Low);
            priorityLevels.Add(PriorityLevel.Medium);
            priorityLevels.Add(PriorityLevel.Urgent);

            this.ComboBoxPriority.ItemsSource = priorityLevels;

            // set default value
            if (this.editMission == null)
            {
                this.ComboBoxPriority.SelectedValue = priorityLevels[0];
            }
            else
            {
                this.Title = "Edit task";
                this.ComboBoxPriority.SelectedValue = this.editMission.Priority;
                this.TextBoxName.Text = this.editMission.Name;
                this.TextBoxDescription.Text = this.editMission.Description;
                this.addButton.Content = "Update";
            }
        }

        DateTime date;
        private void CalendarSelectedDatesChanged(object sender,
        SelectionChangedEventArgs e)
        {
            var calendar = sender as Calendar;

            if (calendar.SelectedDate.HasValue)
            {
                date = calendar.SelectedDate.Value;
            }
        }

        private void OnAddButtonClick(object sender, RoutedEventArgs e)
        {
            if (this.editMission == null)
            {
                var priority = (PriorityLevel)this.ComboBoxPriority.SelectionBoxItem;
                Mission mission = new Mission(this.TextBoxName.Text, this.TextBoxDescription.Text, priority, this.taskDate);

                this.missionFileControler.AddItem(mission);
                this.Close();
            }
            else
            {
                var priority = (PriorityLevel)this.ComboBoxPriority.SelectionBoxItem;
                Mission mission = new Mission(this.TextBoxName.Text, this.TextBoxDescription.Text, priority, this.taskDate);

                this.missionFileControler.DeleteItem(this.editMission);
                this.missionFileControler.AddItem(mission);
                
                this.Close();
            }
        }

        private void OnCancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
