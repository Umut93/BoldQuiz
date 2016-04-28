using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class Level
    {
        public Level (int ID, string Name, int Score, Section Section)
        {
            this.ID = ID;
            this.Name = Name;
            this.Score = Score;
            this.Section = Section;
            Rooms = new List<Room>();
            Quetions = new List<Question>();
        }

        public int ID { get; set; }
        public string Name { get; private set; }
        public int Score { get; private set; }
        public Section Section { get; private set; }
        public List<Room> Rooms { get; private set; }
        public List<Question> Quetions { get; private set; }

        public Level() { }

    }
}
