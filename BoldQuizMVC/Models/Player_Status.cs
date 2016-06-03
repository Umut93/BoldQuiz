using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public  class Player_Status
    {
        public int SavedScore { get; set; }
        public Player Player { get; set; }
        public Room_levels Room_levels { get; set; }


        public Player_Status() { }


        public Player_Status(int SavedScore, Player PLayer, Room_levels Room_levels)
        {
            this.SavedScore = SavedScore;
            this.Player = Player;
            this.Room_levels = Room_levels;

        }

    }
}
