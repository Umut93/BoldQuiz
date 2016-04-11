using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class Level
    {
        public Level (int ID, string name, int score, Section section)
        {
            this.ID = ID;
            this.name = name;
            this.score = score;
            this.section = section;
            List<Room> rooms = new List<Room>();
            List<Question> quetions = new List<Question>();
        }

        public int ID { get; set; }
        public string name { get; private set; }
        public int score { get; private set; }
        public Section section { get; private set; }
        public List<Room> rooms { get; private set; }
        public List<Question> quetions { get; private set; }

    }
}
