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

        //Finding a player status (savedScore, playerid, a specifik room with a specific levelid)
        public Player_Status findPlayerStatus(int playerID, int room_levels_id)
        {
            string sql = "SELECT * FROM Player_status where player_id = @player_id AND room_levels_id = @room_levels_id";
            return  con.Query<Player_Status>(sql, new { player_id = playerID, room_levels_id = room_levels_id}).FirstOrDefault();

        }

        //Adding player_status in the table
        public void addPlayerStatus(Player_Status player_status)
        {
            string sql = "INSERT INTO Player_status VALUES (@SavedScore, @playerID, @Room_levels_id)";
            con.Execute(sql, new { SavedScore = player_status.SavedScore, playerID = player_status.Player.Id, Room_levels_id = player_status.Room_levels.ID});

        }

        //Updating a player_status in the table
        public void updatePlayerStatus(Player_Status player_status)
        {
            string sql = "UPDATE Player_status SET savedScore = @SavedScore, player_id = @playerID, room_levels_id = @Room_levels_id WHERE ID = @id ";

            con.Execute(sql, new {SavedScore = player_status.SavedScore, playerID = player_status.Player.Id, room_levels_id = player_status.Room_levels.ID, id = player_status.ID});
        }

    }
   
}
