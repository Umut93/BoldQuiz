using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Room
    {

        public Room(int ID,int point,  Section Section) {

            this.ID = ID;
            this.Point = point;
            this.Section = Section;
            List<Player> players = new List<Player>();
            List<Room_levels> levels = new List<Room_levels>();
        }

        public Room(int Point, Section Section)
        {

            this.Point = Point;
            this.Section = Section;
            List<Player> players = new List<Player>();
            List<Level> levels = new List<Level>();

        }
        public int ID { get; set; }
        public int Point { get; private set; }
        public Section Section { get; private set; }
        public List<Player> Players { get; private set; }
        public List<Room_levels> Levels { get; set; }



    }
}
