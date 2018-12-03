using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;

using Android.Runtime;
using Android.Views;
using Android.Widget;
using CallerID.Database.Tables;
using SQLite;

namespace CallerID.Database
{
    class SQLiteDB<T> where T : new()
    {
        public SQLiteDB()
        {

        }
        string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Fragement.db3");
        public void createDb()
        {
            try
            {   
                var db = new SQLiteConnection(dbpath);
            }
            catch (Exception ex)
            {
            }
        }
        //code to create table
        public void createTable()
        {
            try
            {
               
                var db = new SQLiteConnection(dbpath);
                db.CreateTable<T>();
            }
            catch (Exception ex)
            {
            }
        }
        public void insert(T data)
        {
            try
            {
               
                var db = new SQLiteConnection(dbpath);
                db.Insert(data);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void update(T data)
        {
            try
            {

                var db = new SQLiteConnection(dbpath);
                db.Update(data);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public bool Delete (string mobileNo)
        {
            try
            {
                var db = new SQLiteConnection(dbpath);
                TableMapping map = new TableMapping(typeof(SQLiteDB<T>), CreateFlags.None);
                object[] ob = new object[0];
                var count = db.Query(map, "Delete FROM PhoneBookDetailsTbl WHERE MobileNo = '" + mobileNo + "' ", ob).Count;
                if (count >= 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

            }
            return false;
        }
        public bool Update(string name,string mobileNo)
        {
            try
            {
                var db = new SQLiteConnection(dbpath);
                TableMapping map = new TableMapping(typeof(SQLiteDB<T>), CreateFlags.None);
                object[] ob = new object[0];
                var count = db.Query(map, "Update PhoneBookDetailsTbl set Name='" + name +"' WHERE MobileNo = '" + mobileNo + "' ", ob).Count;
                if (count >= 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

            }
            return false;
        }
        public void clear()
        {
            try
            {

                var db = new SQLiteConnection(dbpath);
                db.DeleteAll<T>();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void DropTable()
        {
            
            var db = new SQLiteConnection(dbpath);
            db.DropTable<T>();
        }
        public TableQuery<T> GetData()
        {
            try
            {
                var db = new SQLiteConnection(dbpath);
                var data = db.Table<T>();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public bool TableExist(string tableName)
        {
            try
            {                
                var db = new SQLiteConnection(dbpath);
                TableMapping map = new TableMapping(typeof(SQLiteDB<T>), CreateFlags.None);
                object[] ob = new object[0];
                var count = db.Query(map, "SELECT * FROM sqlite_master WHERE type = 'table' AND name = '" + tableName + "'", ob).Count;
                if (count > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

            }
            return false;
        }

    }

}