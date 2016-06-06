using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{

    /// <summary>
    /// Every player has 10-question based on a specific level on a certain room.
    /// Don't pay attetion on SavedScore, the responsibility lies on the player_status object.
    /// </summary>
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
