using System;
using System.IO;
using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;
using Zeving.Services;
using Zeving.Views;

namespace Zeving
{
    public partial class App : Application
    {
        static string tasktuteurdatabaseFileName = "TravauxTuteurs.db3";
        static string inventorydatabaseFileName = "Inventory.db3";
        static string currentSite = "Pueu";
        static string currentTuteur = "L0C0";

        static TaskTuteurServices tt_database;
        public static TaskTuteurServices TaskTuteurDatabase
        {
            get
            {
                if (tt_database == null)
                {
                    tt_database = new TaskTuteurServices(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), tasktuteurdatabaseFileName));
                  //  tt_database = new TaskTuteurServices(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), tasktuteurdatabaseFileName));
                }
                return tt_database;
            }
        }

        public static string CurrentSite
            {
            get {return currentSite; }  
            set {currentSite = value;}
            }

        public static string CurrentTuteur
        {
            get { return currentTuteur; }
            set { currentTuteur = value; }
        }

        static InventoryServices inventory_services;
        public static InventoryServices InventoryDataBase
        {
            get
            {
                if (inventory_services == null)
                {


                 //    inventory_services = new InventoryServices(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), inventorydatabaseFileName));
                inventory_services = new InventoryServices(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), inventorydatabaseFileName));
                }
                return inventory_services;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
