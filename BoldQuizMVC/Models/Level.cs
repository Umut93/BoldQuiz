using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class Level
    {
        public string name;
        public int score;
        public Section section;
        public List<Room> rooms;
        public List<Question> quetions;

    }
}
