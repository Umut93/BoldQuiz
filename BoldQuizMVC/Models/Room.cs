using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Room
    {
        public int SectionID { get; set;}
        public int ID { get; set; }
        public int Point { get; set; }
        public Section Section { get; set; }
        public List<Player> Players { get; set; }
        public List<Room_levels> Levels { get; set; }

        public Room () { }

        public Room(int ID,int point,  Section Section) {

            this.ID = ID;
            this.Point = point;
            this.Section = Section;
            this.SectionID = Section.ID;
            Players = new List<Player>();
            Levels = new List<Room_levels>();
        }

        public Room(int Point, Section Section)
        {

            this.Point = Point;
            this.Section = Section;
            this.SectionID = Section.ID;
            List<Player> players = new List<Player>();
            List<Level> levels = new List<Level>();

        }
       

       



    }
}
