using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using Research.BL;

namespace Research.DAL
{
    public class ThoughtRepository
    {
        DataLayer.ThoughtDatabase db = null;
        protected static string dbLocation;
        protected static ThoughtRepository me;

        static ThoughtRepository()
        {
            me = new ThoughtRepository();
        }

        protected ThoughtRepository()
        {
            dbLocation = DatabaseFilePath;

            db = new Research.DataLayer.ThoughtDatabase(dbLocation);
        }

        public static string DatabaseFilePath
        {
            get
            {
                var sqliteFilename = "ThoughtDb.db3";

	            string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                var path = Path.Combine(libraryPath, sqliteFilename);

                return path;
            }
        }

        public static IEnumerable<Thought> GetThoughts()
        {
            return me.db.GetItems();
        }
    }
}
