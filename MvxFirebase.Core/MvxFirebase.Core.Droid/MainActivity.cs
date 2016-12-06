using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Firebase;
using Firebase.Database;

namespace MvxFirebase.Core.Droid
{
    [Activity( Icon = "@drawable/icon", MainLauncher = true)]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);

            

            var options = new FirebaseOptions.Builder()
                .SetApplicationId("1:14811556559:android:687df68cead1d1d0")
                .SetApiKey("AIzaSyAdoEMJ70lkokeGf9qlotLbICEVhNUO5bs")
                .SetDatabaseUrl("https://vsme-1085.firebaseio.com")
                .SetGcmSenderId("14811556559")
                .Build();
            var firebaseApp = FirebaseApp.InitializeApp(this, options);

            var database = FirebaseDatabase.GetInstance(firebaseApp);

            button.Click += delegate
            {
                button.Text = string.Format("{0} clicks!", count++);

                database.GetReference("test").SetValue("Hello world! " + count);
            };
        }
    }
}


