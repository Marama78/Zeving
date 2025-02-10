using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zeving.Models;
using Zeving.Views;

namespace Zeving.ViewModels
{
    
    public class TaskTuteurViewModel : BaseViewModel
    {

        private TaskTuteur _taskTuteurSelected;
        public TaskTuteur SelectedItem
        {
            get => _taskTuteurSelected;
            set
            {
                SetProperty(ref _taskTuteurSelected, value);
                OnItemSelected(value);
            }
        }

        private int delayTrigger;
        public int DelayTrigger
        {
            get
            {
               
                    return delayTrigger;
            }

            set { delayTrigger = value; }
        }

        private int delayDay;

        public int DelayDay
        {
            get { return delayDay; }
            set { delayDay = value; }
        }


        private int id;
        public string Id
        {
            get { return id.ToString(); }
        }
        private Color zoneColor;
        public Color ZoneColor
        {
            get { return zoneColor; }
            set { zoneColor = value;}
        }
        private string nameOfGeographicPosition;
        public string NameOfGeographicPosition
        {
            get { return nameOfGeographicPosition; }
            set { nameOfGeographicPosition = value; }
        }
        private string ameOfInsideLocation;
        public string NameOfInsideLocation
        {
            get { return ameOfInsideLocation; }
            set { ameOfInsideLocation = value; }
        }
        private string nameOfVanillaLocation;
        public string NameOfVanillaLocation
        {
            get { return nameOfVanillaLocation; }
            set { nameOfVanillaLocation = value; }
        }

        private DateTime dueDate;
        public DateTime DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }

        private List<TaskTuteur> listeTravaux;
        public List<TaskTuteur> ListeTravaux
        {
            get { return listeTravaux; }
            set { listeTravaux = value; }
        }

        public ObservableCollection<TaskTuteur> TaskTuteurs { get; set; }

        public Command cmdAddTask { get; }
        public Command cmdLoadItem { get; }
        public Command<TaskTuteur> ItemTapped { get; }
        public TaskTuteurViewModel()
        {
            TaskTuteurs = new ObservableCollection<TaskTuteur>();
            Title = "Listes des Travaux";
            cmdLoadItem = new Command(async()=>await ExecuteloadItemsCommand());
            ItemTapped = new Command<TaskTuteur>(OnItemSelected);
            cmdAddTask = new Command(OnAddTask);
           
        }


       

       public void SetTuteurLocation(string siteProd, string location)
       {
            NameOfGeographicPosition = siteProd;
            NameOfVanillaLocation = location;
       }
        public void OnAppearing()
        {
            IsBusy = true;
        }
         
        async Task ExecuteloadItemsCommand()
        {
            IsBusy = true;

            try
            {
                TaskTuteurs.Clear();
                 var tt = await App.TaskTuteurDatabase.GetListTaskTeurSortedByDateAsync();

                 foreach (var task in tt)
                 {

                    TimeSpan tempdelay = DateTime.Now - task.DueDate;

                    int duedelay = (int)tempdelay.TotalDays;

                    if (duedelay < 8) task.DelayTrigger = 0;
                    else if (duedelay >= 8 && duedelay <= 16) task.DelayTrigger = 1;
                    else if (duedelay > 16) task.DelayTrigger = 2;
                    else task.DelayTrigger = 5;

                   task.DelayDay = duedelay;

                    TaskTuteurs.Add(task);
                 }

                 //-- ranger par ordre décroissant --
                TaskTuteurs.Reverse();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void OnAddTask(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewTaskTuteurView));
        }
       
        async void OnItemSelected(TaskTuteur tt)
        {
            if (tt == null) return;

            await Shell.Current.GoToAsync($"{nameof(DetailTaskTuteurPage)}?{nameof(DetailTaskTuteurViewModel.TaskTuteurID)}={tt.Id}");    

        }
    }
}
