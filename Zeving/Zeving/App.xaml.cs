using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zeving.Services;
using Zeving.Views;
/*
This software uses Xamarin Community Toolkit

MIT License
SPDX identifier
MIT
License text
MIT License

Copyright (c) <year> <copyright holders>

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice (including the next paragraph) shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

SPDX web page
https://spdx.org/licenses/MIT.html
Notice
This license content is provided by the SPDX project. For more information about licenses.nuget.org, see our documentation.

Data pulled from spdx/license-list-data on February 9, 2023.
*/
namespace Zeving
{
    public partial class App : Application
    {
        static string tasktuteurdatabaseFileName = "TravauxTuteurs.db3";
        static string inventorydatabaseFileName = "Inventory.db3";


        static TaskTuteurServices tt_database;
        public static TaskTuteurServices TaskTuteurDatabase
        {
            get
            {
                if (tt_database == null)
                {
                    tt_database = new TaskTuteurServices(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), tasktuteurdatabaseFileName));
                }
                return tt_database;
            }
        }

        static InventoryServices inventory_services;
        public static InventoryServices InventoryDataBase
        {
            get
            {
                if (inventory_services == null)
                {
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
