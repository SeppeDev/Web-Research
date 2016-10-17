using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

using Research.BL;

namespace Research.DataLayer
{
    public class ThoughtDatabase : SQLiteConnection
    {

        static object locker = new object();

        public ThoughtDatabase(string path) : base (path)
        {
            CreateTable<Thought>();
        }

        public IEnumerable<Thought> GetItems()
        {
            return (from i in Table<Thought>() select i).ToList();
        }
    }
}
