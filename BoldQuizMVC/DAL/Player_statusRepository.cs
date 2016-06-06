using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Dapper;

namespace DAL
{
  public  class Player_statusRepository : BaseRepository
    {
        public Player_statusRepository(string connectionstring) : base(connectionstring)
        {
        }

       
        //Finding a player status (savedScore, playerid, on a specific room with a specific level)
        public Player_Status findPlayerStatus(int playerID, int room_levels_id)
        {
            string sql = "SELECT * FROM Player_status where player_id = @player_id AND room_levels_id = @room_levels_id";
            return  con.Query<Player_Status>(sql, new { player_id = playerID, room_levels_id = room_levels_id}).FirstOrDefault();

        }

        //SavedScore is score the user has got, room_levels are the specific level on a specific room, IsUnlocked  tells about if the level itself is open or closed, warnings are the faults the user has made.
        //Adding player_status in the table. 
        public void addPlayerStatus(Player_Status player_status)
        {
            string sql = "INSERT INTO Player_status VALUES (@SavedScore, @playerID, @Room_levels_id, @isUnlocked, @Warnings)";
            con.Execute(sql, new { SavedScore = player_status.SavedScore, playerID = player_status.Player.Id, Room_levels_id = player_status.Room_levels.ID, isUnlocked = player_status.IsUnlocked, Warnings = player_status.Warnings});

        }

        //Updating a player_status table by the unique identier tuple after completing a quiz.
        public void updatePlayerStatus(Player_Status player_status)
        {
            string sql = "UPDATE Player_status SET savedScore = @SavedScore, player_id = @playerID, isUnlocked = @isUnlocked, Warnings = @Warnings, room_levels_id = @Room_levels_id WHERE ID = @id ";

            con.Execute(sql, new {SavedScore = player_status.SavedScore, playerID = player_status.Player.Id, room_levels_id = player_status.Room_levels.ID, id = player_status.ID, isUnlocked = player_status.IsUnlocked, Warnings = player_status.Warnings});
        }


        //Getting all the player status for one Person in that room_levels he/has participated in.
        public List<Player_Status> GetAllPlayerStatusForOnePLayer(Player player)
        {
            string sql = "Select * from Player_status JOIN Room_levels on room_levels_id = room_levels.ID JOIN[Level] on[Level].ID = level_id where player_id = @player_id";
            return con.Query<Player_Status, Room_levels, Level, Player_Status> (sql,
                (playerStatus, Room_levels, level) => {
                    playerStatus.Room_levels = Room_levels;
                    playerStatus.Room_levels.Level = level;
                    return playerStatus;
                }, 
                new { player_id = player.Id }).ToList();

            

        }

    }
   
}
