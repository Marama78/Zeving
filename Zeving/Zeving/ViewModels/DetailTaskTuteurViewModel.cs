using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Zeving.Models;
using Zeving.Views;

namespace Zeving.ViewModels
{
    [QueryProperty(nameof(TaskTuteurID), nameof(TaskTuteurID))]
    public class DetailTaskTuteurViewModel:BaseViewModel
    {
        public Command CmdCancel { get; }
        public Command CmdDelete { get; }
        public Command CmdLoadDetailledItem { get; }
        public Command CmdUpdate { get; }
        public Command CmdIsToggled { get; }

        public Command ItemTapped { get; }

        public DetailTaskTuteurViewModel()
        {
            Title = "Details";
            Item = new TaskTuteur();
            CmdCancel = new Command(OnCancel);
            CmdLoadDetailledItem = new Command(async () => await LoadTaskTuteurId(TaskTuteurID));
            CmdDelete = new Command(OnDelete);
            CmdUpdate = new Command(UpdateData);
            CmdIsToggled = new Command(SetVisibilityCheckBoxes);
            ItemTapped = new Command(async () => await OnItemSelected());
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


        private string productionSiteName;
        public string ProductionSiteName
        {
            get => productionSiteName;
            set => SetProperty(ref productionSiteName, value);
        }
        private int line;
        public int Line
        {
            get => line;
            set => SetProperty(ref line, value);
        }
        private int column;
        public int Column
        {
            get => column;
            set => SetProperty(ref column, value);
        }
        private string tuteurLocation;
        public string TuteurLocation
        {
            get => tuteurLocation;
            set => SetProperty(ref tuteurLocation, value);
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
        private bool isVanillaBeanEnabled;
        public bool IsVanillaBeanEnabled
        {
            get => isVanillaBeanEnabled;
            set => SetProperty(ref isVanillaBeanEnabled, value);
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

        private bool isUnlockDeleteCmd;
        public bool IsUnlockDeleteCmd
        {

            get => isUnlockDeleteCmd;
            set => SetProperty(ref isUnlockDeleteCmd, value);
        }

        private int taskTuteurID;
        public int TaskTuteurID
        {
            get { return taskTuteurID; }
            set { taskTuteurID = value;
              LoadTaskTuteurId(value);
            }

        }


        //-- variables spécifiques au comportement des checkboxes [rendre visibles les commandes]
        private bool isAddCompostVisible;
        public bool IsAddCompostVisible
        {
            get => isAddCompostVisible;
            set => SetProperty(ref isAddCompostVisible, value);
        }
        private bool isAddSlugKillerVisible;
        public bool IsAddSlugKillerVisible
        {
            get => isAddSlugKillerVisible;
            set => SetProperty(ref isAddSlugKillerVisible, value);
        }
        private bool isNeedsHeallingVisible;
        public bool IsNeedsHeallingVisible
        {
            get => isNeedsHeallingVisible;
            set => SetProperty(ref isNeedsHeallingVisible, value);
        }
        private bool isNeedsFeedingVisible;
        public bool IsNeedsFeedingVisible
        {
            get => isNeedsFeedingVisible;
            set => SetProperty(ref isNeedsFeedingVisible, value);
        }
        private bool isNeedsCleaningLocationVisible;
        public bool IsNeedsCleaningLocationVisible
        {
            get => isNeedsCleaningLocationVisible;
            set => SetProperty(ref isNeedsCleaningLocationVisible, value);
        }
        private bool isFlowerEnabledVisible;
        public bool IsFlowerEnabledVisible
        {
            get => isFlowerEnabledVisible;
            set => SetProperty(ref isFlowerEnabledVisible, value);
        }
        private bool isVanillaBeanEnabledVisible;
        public bool IsVanillaBeanEnabledVisible
        {
            get => isVanillaBeanEnabledVisible;
            set => SetProperty(ref isVanillaBeanEnabledVisible, value);
        }
        private bool didPestsAttackedVisible;
        public bool DidPestsAttackedVisible
        {
            get => didPestsAttackedVisible;
            set => SetProperty(ref didPestsAttackedVisible, value);
        }
        private bool didDiseasesAppearedVisible;
        public bool DidDiseasesAppearedVisible
        {
            get => didDiseasesAppearedVisible;
            set => SetProperty(ref didDiseasesAppearedVisible, value);
        }



        //-- checkboxes travaux finis
        private bool isAddCompostDone;
        public bool IsAddCompostDone
        {
            get => isAddCompostDone;
            set => SetPropertyAndAction(ref isAddCompostDone, value, DoRevealDeletButton);
        }
        private bool isAddSlugKillerDone;
        public bool IsAddSlugKillerDone
        {
            get => isAddSlugKillerDone;
            set => SetPropertyAndAction(ref isAddSlugKillerDone, value, DoRevealDeletButton);
        }
        private bool isNeedsHeallingDone;
        public bool IsNeedsHeallingDone
        {
            get => isNeedsHeallingDone;
            set => SetPropertyAndAction(ref isNeedsHeallingDone, value, DoRevealDeletButton);
        }
        private bool isNeedsFeedingDone;
        public bool IsNeedsFeedingDone
        {
            get => isNeedsFeedingDone;
            set => SetPropertyAndAction(ref isNeedsFeedingDone, value, DoRevealDeletButton);
        }
        private bool isNeedsCleaningLocationDone;
        public bool IsNeedsCleaningLocationDone
        {
            get => isNeedsCleaningLocationDone;
            set => SetPropertyAndAction(ref isNeedsCleaningLocationDone, value, DoRevealDeletButton);
        }
        private bool isFlowerEnabledDone;
        public bool IsFlowerEnabledDone
        {
            get => isFlowerEnabledDone;
            set => SetPropertyAndAction(ref isFlowerEnabledDone, value, DoRevealDeletButton);
        }
        private bool isVanillaBeanEnabledDone;
        public bool IsVanillaBeanEnabledDone
        {
            get => isVanillaBeanEnabledDone;
            set => SetPropertyAndAction(ref isVanillaBeanEnabledDone, value, DoRevealDeletButton);
        }
        private bool didPestsAttackedDone;
        public bool DidPestsAttackedDone
        {
            get => didPestsAttackedDone;
            set => SetPropertyAndAction(ref didPestsAttackedDone, value, DoRevealDeletButton);
        }
        private bool didDiseasesAppearedDone;
        public bool DidDiseasesAppearedDone
        {
            get => didDiseasesAppearedDone;
            set => SetPropertyAndAction(ref didDiseasesAppearedDone, value, DoRevealDeletButton);
        }

        private bool reverseUnlock;
        public bool ReverseUnlock
        {
            get => reverseUnlock;
            set => SetProperty(ref reverseUnlock, value);
        }

        #endregion

        private async void UpdateData()
        {
            Item = GetItem();
            await App.TaskTuteurDatabase.UpdateDataAsync(Item);
        }

        private async void OnDelete()
        {
            await App.TaskTuteurDatabase.DeleteTaskAsync(TaskTuteurID);
            await Shell.Current.GoToAsync("..");
        }

        private async void OnCancel()
        {
            if(!isUnlocked)
            {
                //-- mode Editeur désactivé :
                UpdateData();
            }
             
            await Shell.Current.GoToAsync("..");
        }

        private TaskTuteur GetItem()
        {
            return new TaskTuteur()
            {
                Id = TaskTuteurID,
                NameOfGeographicPosition = ProductionSiteName,
                Line = Line,
                Column = Column,
                TuteurLocation = TuteurLocation,
                IsAddCompost = IsAddCompost,
                IsAddSlugKiller = IsAddSlugKiller,
                IsNeedsHealling = IsNeedsHealling,
                IsNeedsFeeding = IsNeedsFeeding,
                IsNeedsCleaningLocation = IsNeedsCleaningLocation,
                IsFlowerEnabled = IsFlowerEnabled,
                IsVanillaBeanEnabled = IsVanillaBeanEnabled,
                VanillaBeansCount = VanillaBeansCount,
                DidPestsAttacked = DidPestsAttacked,
                DidDiseasesAppeared = DidDiseasesAppeared,

                IsAddCompostDone = IsAddCompostDone,
                IsAddSlugKillerDone = IsAddSlugKillerDone,
                IsNeedsHeallingDone = IsNeedsHeallingDone,
                IsNeedsFeedingDone = IsNeedsFeedingDone,
                IsNeedsCleaningLocationDone = IsNeedsCleaningLocationDone,
                IsFlowerEnabledDone = IsFlowerEnabledDone,
                IsVanillaBeanEnabledDone = IsVanillaBeanEnabledDone,
                DidPestsAttackedDone = DidPestsAttackedDone,
                DidDiseasesAppearedDone = DidDiseasesAppearedDone,

                DueDate = DueDate,
            };
        }

     
        private async Task OnItemSelected()
        {
            IsBusy = true;
            try
            {
                Item = GetItem();
              

                int totalTask = GetTotalTasks();
                int totalDone = GetTotalDone();

                if (DoAllWorksDone())
                {
                    Item.IsHidden = true;
                    IsUnlockDeleteCmd = true;
                }
                else
                {
                    Item.IsHidden = false;
                }
                await App.TaskTuteurDatabase.UpdateDataAsync(Item);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            finally
            { 
                IsBusy = false;
            }
           
        }

        private bool DoAllWorksDone()
        {
            if (GetTotalDone() - GetTotalTasks() == 0) return true;
            return false;
        }
        private int GetTotalTasks()
        {
            int total = 0;

            if (isAddCompost) total++;
            if (isAddSlugKiller) total++;
            if (isNeedsHealling) total++;
            if (isNeedsFeeding) total++;
            if (isNeedsCleaningLocation) total++;
            if (isFlowerEnabled) total++;   
            if (isVanillaBeanEnabled) total++;
            if(didDiseasesAppeared) total++;
            if(didPestsAttacked) total++;
            return total;
        }

        private int GetTotalDone()
        {
            int total = 0;

            if (isAddCompostDone) total++;
            if (isAddSlugKillerDone) total++;
            if (isNeedsHeallingDone) total++;
            if (isNeedsFeedingDone) total++;
            if (isNeedsCleaningLocationDone) total++;
            if (isFlowerEnabledDone) total++;
            if (isVanillaBeanEnabledDone) total++;
            if (didDiseasesAppearedDone) total++;
            if (didPestsAttackedDone) total++;
            return total;
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
                     this.ProductionSiteName = Item.NameOfGeographicPosition;
                    this.Line = Item.Line;
                    this.Column = Item.Column;
                    this.TuteurLocation = Item.TuteurLocation;
                    this.IsAddCompost = Item.IsAddCompost;
                    this.IsAddSlugKiller = Item.IsAddSlugKiller;
                    this.IsNeedsHealling = Item.IsNeedsHealling;
                    this.IsNeedsFeeding = Item.IsNeedsFeeding;
                    this.IsNeedsCleaningLocation = Item.IsNeedsCleaningLocation;
                    this.IsFlowerEnabled = Item.IsFlowerEnabled;
                    this.IsVanillaBeanEnabled = Item.IsVanillaBeanEnabled;
                    this.DidPestsAttacked = Item.DidPestsAttacked;
                    this.DidDiseasesAppeared = Item.DidDiseasesAppeared;

                    this.IsAddCompostDone = Item.IsAddCompostDone;
                    this.IsAddSlugKillerDone = Item.IsAddSlugKillerDone;
                    this.IsNeedsHeallingDone = Item.IsNeedsHeallingDone;
                    this.IsNeedsFeedingDone = Item.IsNeedsFeedingDone;
                    this.IsNeedsCleaningLocationDone = Item.IsNeedsCleaningLocationDone;
                    this.IsFlowerEnabledDone = Item.IsFlowerEnabledDone;
                    this.IsVanillaBeanEnabledDone = Item.IsVanillaBeanEnabledDone;
                    this.DidPestsAttackedDone = Item.DidPestsAttackedDone;
                    this.DidDiseasesAppearedDone = Item.DidDiseasesAppearedDone;
                    this.VanillaBeansCount = Item.VanillaBeansCount;

                    this.DueDate = Item.DueDate;
                }

                SetVisibilityCheckBoxes();
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


        private bool DoUnlockDeleteButtonPermanently()
        {

            Debug.WriteLine("coucou");

            if(DoAllWorksDone()) { return true; }
            return false;
        }


        private void DoRevealDeletButton()
        {
            if (DoUnlockDeleteButtonPermanently()) { IsUnlockDeleteCmd = true; }
            else { IsUnlockDeleteCmd = false; }
        }

        public void SetVisibilityCheckBoxes()
        {
            if (Item == null) return;

            ReverseUnlock = !IsUnlocked;

            IsBusy = true;
            if (!IsUnlocked)
            {
                //-- ne rendre visible que les checkboxes vrais
                IsAddCompostVisible = IsAddCompost;
                IsAddSlugKillerVisible = IsAddSlugKiller;
                IsNeedsHeallingVisible = IsNeedsHealling;
                IsNeedsFeedingVisible = IsNeedsFeeding;
                IsNeedsCleaningLocationVisible = IsNeedsCleaningLocation;
                IsFlowerEnabledVisible = IsFlowerEnabled;
                IsVanillaBeanEnabledVisible = isVanillaBeanEnabled;
                DidPestsAttackedVisible = DidPestsAttacked;
                DidDiseasesAppearedVisible = DidDiseasesAppeared;

                if(DoUnlockDeleteButtonPermanently()) { IsUnlockDeleteCmd = true; }
                else{ IsUnlockDeleteCmd = false; }
            }
            else
            {
                IsAddCompostVisible = true;
                IsAddSlugKillerVisible = true;
                IsNeedsHeallingVisible = true;
                IsNeedsFeedingVisible = true;
                IsNeedsCleaningLocationVisible = true;
                IsFlowerEnabledVisible = true;
                IsVanillaBeanEnabledVisible = true;
                DidPestsAttackedVisible = true;
                DidDiseasesAppearedVisible = true;

                if(!IsUnlockDeleteCmd) { IsUnlockDeleteCmd = true; }
            }
            IsBusy = false;
        }





    }
}
