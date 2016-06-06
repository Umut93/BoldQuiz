using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Every Player_status has an ID. 
    /// Retrieving a specific player_status gives us a piece of information about achieved score, the player who has participated in the specific level on a room.
    /// The unlocked is used to see if the levels in a specific room whether is unlocked or not and finally warnings are the wrongdoing from the player. If == 1 (yellow card), if == 2 (red card).
    /// </summary>
    public class Player_Status
    {
        public int ID { get; set; }
        public int SavedScore { get; set; }
        public Player Player { get; set; }
        public Room_levels Room_levels { get; set; }
        public bool IsUnlocked { get; set; }
        public int Warnings { get; set; }


        public Player_Status() { }


        public Player_Status(int ID, int SavedScore, Player PLayer, Room_levels Room_levels, int Warnings, bool IsUnlocked)
        {
            this.ID = ID;
            this.SavedScore = SavedScore;
            this.Player = Player;
            this.Room_levels = Room_levels;
            this.Warnings = Warnings;
            this.IsUnlocked = IsUnlocked;

        }

    }
}
