using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class Level
    {   public int ID { get; set; }
        public string Name { get; private set; }
        public int Score { get; private set; }
        public Section Section { get;  set; }
        public List<Question> Quetions { get;  set; }
        public List<Room_levels> room_levels { get; set; }
        public int Next_level { get; set; }


        public Level() { }

        public Level (int ID, string Name, int Score, Section Section)
        {
            this.ID = ID;
            this.Name = Name;
            this.Score = Score;
            this.Section = Section;
            Quetions = new List<Question>();
        }
      

      



    }
}
