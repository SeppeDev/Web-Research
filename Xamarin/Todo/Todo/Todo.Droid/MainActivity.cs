using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Todo.BL;

namespace Todo.Droid
{
	[Activity (Label = "Todo.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
        protected Task todo = new Task();

        protected EditText titleEditText;
        protected RadioButton doneRadioButton;

        protected TextView todoTextView;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

            //My code

            //Variables for onscreen widgets 
            titleEditText = FindViewById<EditText>(Resource.Id.etTitle);
            doneRadioButton = FindViewById<RadioButton>(Resource.Id.rbDone);
            var btnAdd = FindViewById<Button>(Resource.Id.bAdd);
            todoTextView = FindViewById<TextView>(Resource.Id.tvTodo);

            FillTextView();

            btnAdd.Click += delegate
            {
                Save();
            };
        }
        
        protected void Save()
        {
            todo.Title = titleEditText.Text;
            todo.Done = doneRadioButton.Checked;
            TodoManager.SaveTodo(todo);

            FillTextView();
        }

        protected void FillTextView()
        {
            var todos = TodoManager.GetTodos();
            todoTextView.Text = "";

            foreach (Task t in todos)
            {
                todoTextView.Text += t.Title + " " + t.Done + "\n";
            }
        }
    }
}


