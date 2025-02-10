using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Zeving.Models;
using Zeving.Views;

namespace Zeving.ViewModels
{
 
    public class SerrePlanificatorViewModel : BaseViewModel
    {

        private ObservableCollection<SerreMapping> dataSerreList;
        public ObservableCollection<SerreMapping> DataSerreList
        {
            get { return dataSerreList; }
            set => SetProperty(ref dataSerreList, value);
        }

        public Command CmdLoatItem { get; }

        public Command CmdRefresh { get; }

        public SerrePlanificatorViewModel()
        {

            DataSerreList = new ObservableCollection<SerreMapping>();

            CmdLoatItem = new Command(async () => await OnLoad());
            ItemTapped = new Command<SerreMapping>(OnItemSelected);
        }
        private string tcode;
        public string Tcode
        {
            get { return tcode; }
            set { tcode = value; }
        }
        private bool hastask;
        public bool Hastask
        {
            get => hastask;
            set =>SetProperty(ref hastask, value);
        }

        public Command ItemTapped { get; }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        private async Task OnLoad()
        {
            IsBusy = true;

          /*  if(DataSerreList.Count>0) 
            {

                Item = await App.TaskTuteurDatabase.LoadDataAsyncByTuteurLocation(App.CurrentTuteur);

                if(Item!=null)
                {
                    var obj = DataSerreList.FirstOrDefault(x => x.Tcode == Item.TuteurLocation);
                    if (!Item.IsHidden)
                    {
                        if (obj != null)
                        {
                            var indexOf = DataSerreList.IndexOf(obj);
                            DataSerreList[indexOf].HasTask = true;
                        }
                    }
                    else
                    {
                        if (obj != null)
                        {
                            var indexOf = DataSerreList.IndexOf(obj);
                            DataSerreList[indexOf].HasTask = false;
                        }
                    }
                }

                IsBusy = false;  
                return; 
            }*/

            DataSerreList.Clear();

            DataSerreList = new ObservableCollection<SerreMapping>();

            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    int row = i + 1;
                    int col = j + 1;

                    SerreMapping mapping = new SerreMapping()
                    {
                        Tcode = "L" + row + "C" + col,
                        HasTask = false,
                    };


                    Item = await App.TaskTuteurDatabase.LoadDataAsyncByTuteurLocation(mapping.Tcode);

                    if (Item != null)
                    {
                        if (!Item.IsHidden) {mapping.HasTask = true; }
                        else
                        {
                            Debug.WriteLine("Item" + Item.TuteurLocation + "is hidden");
                        }

                    }

                    DataSerreList.Add(mapping);
                }
            }
            IsBusy = false;
        }


        private string tuteurLocation;
        public string TuteurLocation
        {
            get { return tuteurLocation; }
            set { tuteurLocation = value; }
        }

        private TaskTuteur item;
        public TaskTuteur Item
        {
            get { return item; }
            set { item = value; }
        }

        async void OnItemSelected(SerreMapping tt)
        {

            //----------------
            App.CurrentSite = "PUEU";


            App.CurrentTuteur = tt.Tcode;
            Debug.WriteLine("open data for " + tt.Tcode);


            Item = await App.TaskTuteurDatabase.LoadDataAsyncByTuteurLocation(tt.Tcode);

           


            if (Item != null && Item.TuteurLocation==tt.Tcode)
            {
                await Shell.Current.GoToAsync($"{nameof(DetailTaskTuteurPage)}?{nameof(DetailTaskTuteurViewModel.TaskTuteurID)}={Item.Id}");
            }
            else
            {
                await Shell.Current.GoToAsync(nameof(NewTaskTuteurView));
            }
        }

    }
}
