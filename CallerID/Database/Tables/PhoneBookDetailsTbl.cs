using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace CallerID.Database.Tables
{
  public  class PhoneBookDetailsTbl
    {
        [PrimaryKey, AutoIncrement]
        public Int32 Id { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
    }
}