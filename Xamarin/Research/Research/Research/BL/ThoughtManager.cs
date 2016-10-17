using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Research.DAL;

namespace Research.BL
{
    public class ThoughtManager
    {
        static ThoughtManager()
        {

        }

        public static IList<Thought> GetThoughts()
        {
            return new List<Thought>(DAL.ThoughtRepository.GetThoughts());
        }
    }
}
