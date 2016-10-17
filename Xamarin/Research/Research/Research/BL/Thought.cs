using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

namespace Research.BL
{
    public class Thought
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Content { get; set; }
        
        public bool Cool { get; set; }
    }
}
