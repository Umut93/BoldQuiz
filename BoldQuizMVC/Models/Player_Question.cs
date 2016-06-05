using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{

    //Player is not used.
   public class Player_Question
    {

        public int SavedScore { get; set; }
        public Player Player { get; set; }
        public Room_levels Room_levels { get; set; }

        public Player_Question() { }

        public Player_Question(int SavedScore, Player Player, Room_levels Room_levels)
        {
            this.SavedScore = SavedScore;
            this.Player = Player;
            this.Room_levels = Room_levels;
        }
    }
}
