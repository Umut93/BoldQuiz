using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Room
    {

        public Room(int ID,int point,  Section section) {

            this.ID = ID;
            this.point = point;
            this.section = section;
            List<Player> players = new List<Player>();
            List<Level> levels = new List<Level>();
        }
        public int ID { get; set; }
        public int point { get; private set; }
        public Section section { get; private set; }
        public List<Player> players { get; private set; }
        public List<Level> levels { get; private set; }



    }
}
