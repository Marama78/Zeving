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



        public void UpdateNameSite(ref int ID)
        {
            try
            {
                switch (ID)
                {
                    case 0:
                        nameOfGeographicPosition = "Pueu";
                        break;
                    case 1:
                        nameOfGeographicPosition = "Punui";
                    break;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
            }
        }

        public void UpdateNameZone(ref int ID)
        {
            try
            {
                switch (ID)
                {
                    case 0:
                        NameOfInsideLocation = "Z1A";
                        break;
                    case 1:
                        NameOfInsideLocation = "Z1B";
                        break;
                    case 2:
                        NameOfInsideLocation = "Z2A";
                        break;
                    case 3:
                        NameOfInsideLocation = "Z2B";
                        break;
                    case 4:
                        NameOfInsideLocation = "Z3A";
                        break;
                    case 5:
                        NameOfInsideLocation = "Z3B";
                        break;

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
            }
        }

        public void UpdateNameTuteur(ref int ID)
        {
            try
            {
                switch (ID)
                {
                    case 0:
                        NameOfVanillaLocation = "A";
                        break;
                    case 1:
                        NameOfVanillaLocation = "B";
                        break;
                    case 2:
                        NameOfVanillaLocation = "C";
                        break;
                    case 3:
                        NameOfVanillaLocation = "D";
                        break;
                    case 4:
                        NameOfVanillaLocation = "E";
                        break;
                    case 5:
                        NameOfVanillaLocation = "1";
                        break;
                    case 6:
                        NameOfVanillaLocation = "2";
                        break;
                    case 7:
                        NameOfVanillaLocation = "3";
                        break;
                    case 8:
                        NameOfVanillaLocation = "4";
                        break;
                    case 9:
                        NameOfVanillaLocation = "5";
                        break;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
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
        }


        private bool ValidateSave()
        {
            return !string.IsNullOrWhiteSpace(NameOfGeographicPosition) 
               && !string.IsNullOrWhiteSpace(NameOfVanillaLocation) 
               && !string.IsNullOrWhiteSpace(NameOfInsideLocation);
        }


        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void SaveTask(object obj)
        {
           

          //  if (ValidateSave()) return;

            TaskTuteur tt = new TaskTuteur()
            {
                NameOfGeographicPosition = this.NameOfGeographicPosition,
                NameOfInsideLocation = this.NameOfInsideLocation,
                NameOfVanillaLocation = this.NameOfVanillaLocation,
                IsAddCompost = this.IsAddCompost,
                IsAddSlugKiller = this.IsAddSlugKiller,
                IsNeedsHealling = this.IsNeedsHealling,
                IsNeedsFeeding = this.IsNeedsFeeding,
                IsNeedsCleaningLocation = this.IsNeedsCleaningLocation,
                IsFlowerEnabled = this.IsFlowerEnabled,
                IsVanillaBeanEndabled = this.IsVanillaBeanEndabled,
                VanillaBeansCount = this.VanillaBeansCount,
                DidPestsAttacked = this.DidPestsAttacked,
                DidDiseasesAppeared = this.DidDiseasesAppeared,
                DueDate = this.DueDate,
            };
            Debug.WriteLine("///////////////////////////////////////////");
            Debug.WriteLine("tt is : " + NameOfGeographicPosition);
            Debug.WriteLine("date is : " + DueDate);
            Debug.WriteLine("///////////////////////////////////////////");
            await App.TaskTuteurDatabase.SaveTaskAsync(tt);
          
            
            await Shell.Current.GoToAsync("..");
        }

        
    }
}
