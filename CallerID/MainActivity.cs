using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using CallerID.Database;
using CallerID.Database.Tables;
using CallerID.Resources.fragment;
using System;

namespace CallerID
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        SQLiteDB<PhoneBookDetailsTbl> sQLiteDB;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);

                SetContentView(Resource.Layout.activity_main);
                // Fragment mainMenu = new MainMenuFragment();
                Fragment mainMenu = new DashBoardScreen_Fragment();
                FragmentTransaction fragmentTransaction = FragmentManager.BeginTransaction();
                fragmentTransaction.SetTransition(FragmentTransit.EnterMask);
                fragmentTransaction.Add(Resource.Id.fragment_container, mainMenu);
                fragmentTransaction.Commit();
                sQLiteDB = new SQLiteDB<PhoneBookDetailsTbl>();
                sQLiteDB.createDb();
                sQLiteDB.createTable();
            }
            catch (Exception ex)
            { }

        }

        public void textToast(string textToDisplay)
        {
            Toast.MakeText(this,
            textToDisplay, ToastLength.Long).Show();
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}

