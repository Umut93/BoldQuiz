using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Room_levels
    {
        public string ID { get; set; }
        public Boolean IsUnlocked { get; set; }
        public Boolean IsCompleted { get; set; }
        public Room Room { get; set; }
        public Level Level { get; set; }


        public Room_levels(string ID, Boolean IsUnclocked, Boolean IsCompleted, Room room, Level level)  {

            this.ID = ID;
            this.IsUnlocked =IsUnlocked ;
            this.IsCompleted = IsCompleted;
            this.Room = room;
            this.Level = level;
        }

        public Room_levels() { }

    }

  
}
