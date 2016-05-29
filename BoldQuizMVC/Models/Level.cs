using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class Level
    {
        public int ID {get; set;}
        public string Name { get; set;}
        public int Score { get; set;}
        public Section Section {get;  set;}
        public List<Question> Quetions {get;  set;}
        public List<Room_levels> Room_levels {get; set;}
        public int Next_level {get; set;}


        public Level() { }

        public Level (int ID, string Name, int Score, Section Section, int Netxt_level)
        {
            this.ID = ID;
            this.Name = Name;
            this.Score = Score;
            this.Section = Section;
            this.Next_level = Netxt_level;
            Quetions = new List<Question>();
            Room_levels = new List<Room_levels>();

        }
      

      



    }
}
