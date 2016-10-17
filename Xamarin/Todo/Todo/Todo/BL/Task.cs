using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace Todo.BL
{
    public class Task
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Title { get; set; }
        public bool Done { get; set; }
    }
}
