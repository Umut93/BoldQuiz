using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Room_levels
    {
        public int ID {get; set;}
        public bool IsCompleted {get; set;}
        public Room Room {get; set;}
        public Level Level {get; set;} 
       
       
        public Room_levels() { }

        public Room_levels(int ID, bool IsCompleted, Room room, Level level)  {

            this.ID = ID;
            this.IsCompleted = IsCompleted;
            this.Room = room;
            this.Level = level;
        }

       

    }

  
}
