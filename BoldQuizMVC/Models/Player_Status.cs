﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public  class Player_Status
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
