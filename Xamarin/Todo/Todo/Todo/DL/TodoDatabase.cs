using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SQLite;

using Todo.BL;

namespace Todo.DL
{
    public class TodoDatabase : SQLiteConnection
    {

        public TodoDatabase (string path) : base (path)
        {
            CreateTable<Task>();
        }

        public Task GetItem (int id)
        {
            return Table<Task>().FirstOrDefault(x => x.ID == id);
        }

        public IEnumerable<Task> GetItems()
        {
            return (from i in Table<Task>() select i).ToList();
        }

        public int SaveItem( Task item)
        {
            /*if (item.ID != 0)
            {
                Update(item);
                return item.ID;
            }
            else
            {*/
                return Insert(item);
            /*}*/
        }
    }
}
