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
        public List<Room> rooms { get; set; }
        public List<Level> levels { get; set; }


        public Room_levels(string ID, Boolean IsUnclocked, Boolean IsCompleted)  {

            this.ID = ID;
            this.IsUnlocked =IsUnlocked ;
            this.IsCompleted = IsCompleted;
            rooms = new List<Room>();
            levels = new List<Level>();
        }

    }

  
}
