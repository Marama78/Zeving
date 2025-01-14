using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
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

        private bool isAddCompost;
        public bool IsAddCompost
        {
            get { return isAddCompost; }
            set { isAddCompost = value; }
        }
        private bool isAddSlugKiller;
        public bool IsAddSlugKiller
        {
            get { return isAddSlugKiller; }
            set { isAddSlugKiller = value; }
        }
        private bool isNeedsHealling;
        public bool IsNeedsHealling
        {
            get { return isNeedsHealling; }
            set { isNeedsHealling = value; }
        }
        private bool isNeedsFeeding;
        public bool IsNeedsFeeding
        {
            get { return isNeedsFeeding; }
            set { isNeedsFeeding = value; }
        }
        private bool isNeedsCleaningLocation;
        public bool IsNeedsCleaningLocation
        {
            get { return isNeedsCleaningLocation; }
            set { isNeedsCleaningLocation = value; }
        }
        private bool isFlowerEnabled;
        public bool IsFlowerEnabled
        {
            get { return isFlowerEnabled; }
            set { isFlowerEnabled = value; }
        }
        private bool isVanillaBeanEndabled;
        public bool IsVanillaBeanEndabled
        {
            get { return isVanillaBeanEndabled; }
            set { isVanillaBeanEndabled = value; }
        }
        private bool didPestsAttacked;
        public bool DidPestsAttacked
        {
            get { return didPestsAttacked; }
            set { didPestsAttacked = value; }
        }
        private bool didDiseasesAppeared;
        public bool DidDiseasesAppeared
        {
            get { return didDiseasesAppeared; }
            set { didDiseasesAppeared = value; }
        }

        private int vanillaBeansCount;
        public int VanillaBeansCount
        {
            get { return vanillaBeansCount; }
            set { vanillaBeansCount = value; }
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


              /*  for (int i = tt.Count; i >0 ; i--)
                {
                    TaskTuteurs.Add(tt[i]);
                }*/


                 foreach (var task in tt)
                 {
                     TaskTuteurs.Add(task);
                 }

                TaskTuteurs.Reverse();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("**************************");
                Debug.WriteLine(ex);
                Debug.WriteLine("**************************");
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
