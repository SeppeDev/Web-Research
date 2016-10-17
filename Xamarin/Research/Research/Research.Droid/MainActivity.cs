using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using SQLite;
using Research.BL;

namespace Research.Droid
{
	[Activity (Label = "Research.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

            //My code

            //Variables for onscreen widgets
            var txtvwContent = FindViewById<TextView>(Resource.Id.txtvwContent);
            var rbCool = FindViewById<RadioButton>(Resource.Id.rbCool);
            var btnAdd = FindViewById<Button>(Resource.Id.AddButton);
            var txtvwToughts = FindViewById<TextView>(Resource.Id.txtvwThoughts);

            //Database path
/*            var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var pathToDatabase = System.IO.Path.Combine(docsFolder, "db_sqlnet.db");

            var db = new SQLiteConnection(pathToDatabase);

            //Create table
            db.CreateTable<Thought>();

            //AddThought
            btnAdd.Click += delegate
            {
                var newThought = new Thought { Content = txtvwContent.Text, Cool = rbCool.Checked };

                db.Insert(newThought);

                var table = db.Table<Thought>();

                foreach (Thought t in table)
                {
                    txtvwToughts.Text += t.Content + " " + t.Cool + "\n";
                }

                //var result = insertUpdateData(new Thought { Content = txtvwContent.Text, Cool = rbCool.Checked }, pathToDatabase);
                //var records = findNumberRecords(pathToDatabase);

                //txtvwToughts.Text += result + "\n" + records + "\n";
            };*/

            txtvwToughts.Text += ThoughtManager.GetThoughts();


        }

        //Create Database
        private string createDatabase(string path)
        {
            try
            {
                var connection = new SQLiteAsyncConnection(path);
                connection.CreateTableAsync<Thought>();

                return "Database created";
            }
            catch (SQLiteException exception)
            {
                return exception.Message;
            }
        }

        //Insert
        private string insertUpdateData(Thought data, string path)
        {
            try
            {
                var database = new SQLiteAsyncConnection(path);

                if (database.InsertAsync(data) != null)
                {
                    database.UpdateAsync(data);
                }

                return "Single data file inserted or updated";
            }
            catch (SQLiteException exception)
            {
                return exception.Message;
            }
        }

        //Count
        private string findNumberRecords(string path)
        {
            try
            {
                var db = new SQLiteConnection(path);
                // this counts all records in the database, it can be slow depending on the size of the database
                var count = db.ExecuteScalar<int>("SELECT Count(*) FROM Thought");

                // for a non-parameterless query
                // var count = db.ExecuteScalar<int>("SELECT Count(*) FROM Person WHERE FirstName="Amy");

                return count.ToString();
            }
            catch (SQLiteException exception)
            {
                return exception.Message;
            }
        }
    }
}


