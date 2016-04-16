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
        public List<Room> Rooms { get; set; }
        public List<Level> Levels { get; set; }


        public Room_levels(string ID, Boolean IsUnclocked, Boolean IsCompleted)  {

            this.ID = ID;
            this.IsUnlocked =IsUnlocked ;
            this.IsCompleted = IsCompleted;
            Rooms = new List<Room>();
            Levels = new List<Level>();
        }

    }

  
}
