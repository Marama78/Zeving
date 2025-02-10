using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Xamarin.Forms;

namespace Zeving.Services
{
    public class SharedServices
    {
        public void GetJsonFromGoogleDrive(string destination)
        {

            const string URL = "https://drive.google.com/uc?export=download&id=1rNJwn7E9qNYU5l1s9Z4-IAlVyy-j_a6R";

            string datataskJson = string.Empty;

            using (var webclient = new WebClient())
            {
                try //-- thread du réseau
                {
                    // datataskJson= webclient.DownloadString(URL);


                    webclient.DownloadStringCompleted += (object sender, DownloadStringCompletedEventArgs e) =>
                    {
                        Console.WriteLine("données téléchargées " + e.Result);
                    };

                    webclient.DownloadStringAsync(new Uri(URL));

                    //-- accéder au thread principal
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        // displayalert()
                    });
                }
                catch (Exception ex) 
                {

                    Device.BeginInvokeOnMainThread( () =>
                    {
                      // displayalert()
                    });

                    return;
                }

            }

        }
    }
}
