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
using CallerID.Database.Tables;

namespace CallerID.CustomControl
{
    class CusotmListAdapter : BaseAdapter<PhoneBookDetailsTbl>
    {
        Activity context;
        List<PhoneBookDetailsTbl> list;
        View view;

        public CusotmListAdapter(Activity _context, List<PhoneBookDetailsTbl> _list)
            : base()
        {
            this.context = _context;
            this.list = _list;
        }

        public override int Count
        {
            get { return list.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override PhoneBookDetailsTbl this[int index]
        {
            get { return list[index]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            try
            {
                view = convertView;
                if (view == null)
                    view = context.LayoutInflater.Inflate(Resource.Layout.ListItemRow, parent, false);

                PhoneBookDetailsTbl item = this[position];
                view.FindViewById<TextView>(Resource.Id.tvName).Text = item.Name;
                view.FindViewById<TextView>(Resource.Id.tvMobileNo).Text = item.MobileNo;
            }
            catch(Exception ex) 
                { 
                }
            return view;
        }
    }
}