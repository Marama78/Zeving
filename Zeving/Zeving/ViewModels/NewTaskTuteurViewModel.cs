using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;
using Zeving.Models;

namespace Zeving.ViewModels
{
    public class NewTaskTuteurViewModel : BaseViewModel
    {
      
        private string nameOfGeographicPosition;
        public string NameOfGeographicPosition
        {
            get { return nameOfGeographicPosition; }
            set { 
                nameOfGeographicPosition = value;
                Debug.WriteLine("new name is " + value);
            }
        }
        private string ameOfInsideLocation;
        public string NameOfInsideLocation
        {
            get { return ameOfInsideLocation; }
            set { ameOfInsideLocation = value; }
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

        private DateTime dueDate = DateTime.Today;
        public DateTime DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }


        private int selectedSitePicker;
        public int SelectedSitePicker
        {
            get { return selectedSitePicker; }
            set { 
                selectedSitePicker = value;
                UpdateNameSite(ref value);
            }
        }

        private int line;
        public int Line
            { get { return line; } set { line = value; } }

        private int column;
        public int Column
        { get { return column; } set { column = value; } }


        public void UpdateNameSite(ref int ID)
        {
            IsBusy = true;
            try
            {
                switch (ID)
                {
                    case 0:
                        NameOfGeographicPosition = "Pueu";
                        break;
                    case 1:
                        NameOfGeographicPosition = "Punui";
                    break;
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

        public void UpdateLineLocation(ref int ID)
        {
            IsBusy = true;
            try
            {
                line = ID+1;
                TuteurLocation = "L" + line + "C" + column;
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

       
        public void UpdateColumnLocation(ref int ID)
        {
            IsBusy = true;
            try
            {
                column = ID+1;
                TuteurLocation = "L" + line + "C" + column;
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

        public Command cmdSave { get;}
        public Command cmdCancel { get;}
        public NewTaskTuteurViewModel()
        {
            dueDate = DateTime.Now;

            cmdSave = new Command(SaveTask);
            cmdCancel = new Command(OnCancel);
            this.PropertyChanged += (_,__) => cmdSave.ChangeCanExecute();

            NameOfGeographicPosition = App.CurrentSite;
            TuteurLocation = App.CurrentTuteur;
        }


        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void SaveTask(object obj)
        {
            TaskTuteur tt = new TaskTuteur()
            {
                NameOfGeographicPosition = this.NameOfGeographicPosition,
                Line = this.Line,
                Column = this.Column,
                TuteurLocation = this.TuteurLocation,
                IsAddCompost = this.IsAddCompost,
                IsAddSlugKiller = this.IsAddSlugKiller,
                IsNeedsHealling = this.IsNeedsHealling,
                IsNeedsFeeding = this.IsNeedsFeeding,
                IsNeedsCleaningLocation = this.IsNeedsCleaningLocation,
                IsFlowerEnabled = this.IsFlowerEnabled,
                IsVanillaBeanEnabled = this.IsVanillaBeanEndabled,
                VanillaBeansCount = this.VanillaBeansCount,
                DidPestsAttacked = this.DidPestsAttacked,
                DidDiseasesAppeared = this.DidDiseasesAppeared,
                DueDate = this.DueDate,
            };
           
            await App.TaskTuteurDatabase.SaveTaskAsync(tt);
            
            await Shell.Current.GoToAsync("..");
        }

        
    }
}
