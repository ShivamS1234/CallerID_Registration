using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using CallerID.CustomControl;
using CallerID.Database;
using CallerID.Database.Tables;

namespace CallerID.Resources.fragment
{
    public class DashBoardScreen_Fragment : Fragment
    {
        string mobileNo, userName;
        View view;
        SQLiteDB<PhoneBookDetailsTbl> _sQLiteDB;
        List<PhoneBookDetailsTbl> lstBarcodeDetails;
        private ListView pckgListView;
        PhoneBookDetailsTbl _phoneBookDetailsTbl;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            base.OnCreate(savedInstanceState);
            _sQLiteDB = new SQLiteDB<PhoneBookDetailsTbl>();
            _phoneBookDetailsTbl = new PhoneBookDetailsTbl();
            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            try
            {
                base.OnCreateView(inflater, container, savedInstanceState);
                view = inflater.Inflate(Resource.Layout.DashBoardScreen_Fragment, container, false);

                //bind here control
                Button saveButton = view.FindViewById<Button>(Resource.Id.btnSave);
                saveButton.Click += SaveButton_Click;
                Button showButton = view.FindViewById<Button>(Resource.Id.btnShow);
                showButton.Click += ShowButton_Click;
                Button updateButton = view.FindViewById<Button>(Resource.Id.btnUpdate);
                updateButton.Click += UpdateButton_Click;
                Button DeleteButton = view.FindViewById<Button>(Resource.Id.btnDelete);
                DeleteButton.Click += DeleteButton_Click;
                //end
                show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            
            }
            return view;
        }

        public void show()
        {
            lstBarcodeDetails = _sQLiteDB.GetData().ToList<PhoneBookDetailsTbl>();
            //var todayData = lstBarcodeDetails.Where(d => d.Date == Convert.ToString(System.DateTime.Now.Date.ToString("mm-dd-yyyy")));
            if (lstBarcodeDetails != null)
            {
                pckgListView = view.FindViewById<ListView>(Resource.Id.lstViewPackageDetail);

                pckgListView.Adapter = new CusotmListAdapter(this.Activity, lstBarcodeDetails);
            }
            else
            {
                (Activity as MainActivity).textToast("No package found!");
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                mobileNo = Convert.ToString(view.FindViewById<EditText>(Resource.Id.txtMobileNo).Text);
                userName = Convert.ToString(view.FindViewById<EditText>(Resource.Id.txtName).Text);
                if (string.IsNullOrEmpty(mobileNo))
                {
                    (Activity as MainActivity).textToast("Please enter valid mobile no.");
                }
                if (string.IsNullOrEmpty(userName))
                {
                    (Activity as MainActivity).textToast("Please enter valid Name.");

                }
                else
                {
                    _phoneBookDetailsTbl.Name = userName;
                    _phoneBookDetailsTbl.MobileNo = mobileNo;
                    _sQLiteDB.insert(_phoneBookDetailsTbl);
                    (Activity as MainActivity).textToast("Phone Book Details User Name: " + userName + ", Mobile No. " + mobileNo + ") saved");
                    //Fragment mainMenuFragment = new MainMenuFragment();
                    //FragmentTransaction fragmentTransaction = FragmentManager.BeginTransaction();
                    //fragmentTransaction.SetTransition(FragmentTransit.EnterMask);
                    //fragmentTransaction.Replace(Resource.Id.fragment_container, mainMenuFragment);
                    //fragmentTransaction.Commit();
                    show();
                }

            }
            catch (Exception ex) { }
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            try
            {
                show();
            }
            catch (Exception ex) { }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                mobileNo = Convert.ToString(view.FindViewById<EditText>(Resource.Id.txtMobileNo).Text);
                userName = Convert.ToString(view.FindViewById<EditText>(Resource.Id.txtName).Text);
                if (string.IsNullOrEmpty(mobileNo))
                {
                    (Activity as MainActivity).textToast("Please enter valid mobile no.");
                }
                if (string.IsNullOrEmpty(userName))
                {
                    (Activity as MainActivity).textToast("Please enter valid Name.");
                }
                else
                {
                    _sQLiteDB.Update(userName, mobileNo);
                    (Activity as MainActivity).textToast("Phone Book Details User Name: " + userName + ", Mobile No. " + mobileNo + ") upated.");
                    show();
                }

            }
            catch (Exception ex) { }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                mobileNo = Convert.ToString(view.FindViewById<EditText>(Resource.Id.txtMobileNo).Text);
                if (string.IsNullOrEmpty(mobileNo))
                {
                    (Activity as MainActivity).textToast("Please enter valid mobile no.");
                }
                else
                {
                    bool status=_sQLiteDB.Delete(mobileNo);
                    if(status)
                    {
                        (Activity as MainActivity).textToast("Phone Book Details has been deleted.");
                    }
                    else
                    {
                        (Activity as MainActivity).textToast("Phone Book Details does not exist.");
                    }
                    show();
                }

            }
            catch (Exception ex) { }
        }
    }
}