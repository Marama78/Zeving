using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Zeving.Models;

namespace Zeving.ViewModels
{
    [QueryProperty(nameof(TaskTuteurID), nameof(TaskTuteurID))]
    public class DetailTaskTuteurViewModel:BaseViewModel
    {
        public Command cmdCancel { get; }
        public Command cmdDelete { get; }
        public Command cmdLoadDetailledItem { get; }
        public Command cmdUpdate { get; }



        public DetailTaskTuteurViewModel()
        {
          // dueDate = DateTime.Now;
            Title = "Details";
            Item = new TaskTuteur();
            cmdCancel = new Command(OnCancel);
            cmdLoadDetailledItem = new Command(async () => await LoadTaskTuteurId(TaskTuteurID));
            cmdDelete = new Command(OnDelete);
            cmdUpdate = new Command(UpdateData);
            Debug.WriteLine("TasktuteurID is " + taskTuteurID);
        }


        #region variables
        private bool isUnlocked;

        public bool IsUnlocked
        {
            get => isUnlocked;
            set => SetProperty(ref isUnlocked, value);
        }

        private bool toRemove;
        public bool ToRemove
        {
            get => toRemove;
            set => SetProperty(ref toRemove, value);
        }

        private TaskTuteur item;
        public TaskTuteur Item
        {
            get { return item; }
            set
            {
                item = value;
            }
        }


        private string nameOfGeographicPosition;
        public string NameOfGeographicPosition
        {
            get => nameOfGeographicPosition;
            set => SetProperty(ref nameOfGeographicPosition, value);
        }
        private string nameOfInsideLocation;
        public string NameOfInsideLocation
        {
            get => nameOfInsideLocation;
            set => SetProperty(ref nameOfInsideLocation, value);
        }
        private string nameOfVanillaLocation;
        public string NameOfVanillaLocation
        {
            get => nameOfVanillaLocation;
            set => SetProperty(ref nameOfVanillaLocation, value);
        }

        private bool isAddCompost;
        public bool IsAddCompost
        {
            get => isAddCompost;
            set => SetProperty(ref isAddCompost, value);
        }
        private bool isAddSlugKiller;
        public bool IsAddSlugKiller
        {
            get => isAddSlugKiller;
            set => SetProperty(ref isAddSlugKiller, value);
        }
        private bool isNeedsHealling;
        public bool IsNeedsHealling
        {
            get => isNeedsHealling;
            set => SetProperty(ref isNeedsHealling, value);
        }
        private bool isNeedsFeeding;
        public bool IsNeedsFeeding
        {
            get => isNeedsFeeding;
            set => SetProperty(ref isNeedsFeeding, value);
        }
        private bool isNeedsCleaningLocation;
        public bool IsNeedsCleaningLocation
        {
            get => isNeedsCleaningLocation;
            set => SetProperty(ref isNeedsCleaningLocation, value);
        }
        private bool isFlowerEnabled;
        public bool IsFlowerEnabled
        {
            get => isFlowerEnabled;
            set => SetProperty(ref isFlowerEnabled, value);
        }
        private bool isVanillaBeanEndabled;
        public bool IsVanillaBeanEndabled
        {
            get => isVanillaBeanEndabled;
            set => SetProperty(ref isVanillaBeanEndabled, value);
        }
        private bool didPestsAttacked;
        public bool DidPestsAttacked
        {
            get => didPestsAttacked;
            set => SetProperty(ref didPestsAttacked, value);
        }
        private bool didDiseasesAppeared;
        public bool DidDiseasesAppeared
        {
            get => didDiseasesAppeared;
            set => SetProperty(ref didDiseasesAppeared, value);
        }

        private int vanillaBeansCount;
        public int VanillaBeansCount
        {
            get => vanillaBeansCount;
            set => SetProperty(ref vanillaBeansCount, value);
        }

        private DateTime dueDate;
        public DateTime DueDate
        {
            get => dueDate;
            set => SetProperty(ref dueDate, value);
        }

        private int taskTuteurID;
        public int TaskTuteurID
        {
            get { return taskTuteurID; }
            set
            {
                taskTuteurID = value;
                LoadTaskTuteurId(value);
            }

            //-- ne pas utiliser la méthode en dessous ---
            /*  get => taskTuteurID;
              set => SetProperty(ref taskTuteurID, value);*/
        } 
        #endregion


        private async void UpdateData()
        {
            Item = GetItem();
            await App.TaskTuteurDatabase.UpdateDataAsync(Item);

            await Shell.Current.GoToAsync("..");
        }

        private async void OnDelete()
        {
            await App.TaskTuteurDatabase.DeleteTaskAsync(TaskTuteurID);
            await Shell.Current.GoToAsync("..");
        }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private TaskTuteur GetItem()
        {
            return new TaskTuteur()
            {
                Id = TaskTuteurID,
                NameOfGeographicPosition = NameOfGeographicPosition,
                NameOfInsideLocation = NameOfInsideLocation,
                NameOfVanillaLocation = NameOfVanillaLocation,
                IsAddCompost = IsAddCompost,
                IsAddSlugKiller = IsAddSlugKiller,
                IsNeedsHealling = IsNeedsHealling,
                IsNeedsFeeding = IsNeedsFeeding,
                IsNeedsCleaningLocation = IsNeedsCleaningLocation,
                IsFlowerEnabled = IsFlowerEnabled,
                IsVanillaBeanEndabled = IsVanillaBeanEndabled,
                VanillaBeansCount = VanillaBeansCount,
                DidPestsAttacked = DidPestsAttacked,
                DidDiseasesAppeared = DidDiseasesAppeared,
                DueDate = DueDate,
            };
        }

        private void OnUnlockCards()
        {
            isUnlocked = !isUnlocked;
        }

        public async Task LoadTaskTuteurId(int taskTuteurID)
        {
            IsBusy = true;
            try
            {
                Debug.WriteLine("Loading command TasktuteurID is " + taskTuteurID);
                Item = await App.TaskTuteurDatabase.LoadDataAsyncById(taskTuteurID);

                if (Item != null)
                {
                     this.NameOfGeographicPosition = Item.NameOfGeographicPosition;
                    this.NameOfInsideLocation = Item.NameOfInsideLocation;
                    this.NameOfVanillaLocation = Item.NameOfVanillaLocation;
                    this.IsAddCompost = Item.IsAddCompost;
                    this.IsAddSlugKiller = Item.IsAddSlugKiller;
                    this.IsNeedsHealling = Item.IsNeedsHealling;
                    this.IsNeedsFeeding = Item.IsNeedsFeeding;
                    this.IsNeedsCleaningLocation = Item.IsNeedsCleaningLocation;
                    this.IsFlowerEnabled = Item.IsFlowerEnabled;
                    this.IsVanillaBeanEndabled = Item.IsVanillaBeanEndabled;
                    this.VanillaBeansCount = Item.VanillaBeansCount;
                    this.DidPestsAttacked = Item.DidPestsAttacked;
                    this.DidDiseasesAppeared = Item.DidDiseasesAppeared;
                    this.DueDate = Item.DueDate;
                    this.dueDate = Item.DueDate;
                }

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








    }
}
