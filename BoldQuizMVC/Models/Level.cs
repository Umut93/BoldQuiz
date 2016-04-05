using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class Level
    {
        public string name { get; private set; }
        public int score { get; private set; }
        public Section section { get; private set; }
        public List<Room> rooms { get; private set; }
        public List<Question> quetions { get; private set; }

    }
}
