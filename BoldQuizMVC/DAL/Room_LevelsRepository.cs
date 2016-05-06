using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using Models;
using System.Threading.Tasks;

namespace DAL
{
    public class Room_LevelsRepository : BaseRepository
    {
        public Room_LevelsRepository(string connectionstring) : base(connectionstring)
        {
        }

        //Jeg joiner to tabeller Room_levels og Level sammen og deres information befolker jeg på hver af deres objekter. Returner jeg Room_levels! I det room_level som har en enkelt Level som objekt, bliver den befolket med level. Se det som venstre tabel og højre tabel!
        public List<Room_levels> getRoom_Levels(int room_id)
        {
            string sql = "SELECT * FROM Room_levels JOIN [Level] on level_id = Level.ID where room_id = @room_id";
            return con.Query<Room_levels, Level, Room_levels>(sql, (room_level, level) => { room_level.Level = level; return room_level; }, new { room_id = room_id }).ToList();
        }

        //Joining Room_levels + Level + Room. Every Room has its own id and level_id. Its function after sql string!
        public Room_levels getRoom_level(int room_id, int level_id)
        {
            string sql = "SELECT * FROM Room_levels JOIN [Level] on level_id = Level.ID JOIN Room on room_id = Room.ID where room_id = @room_id AND level_id = @level_id";
            return con.Query<Room_levels, Level, Room, Room_levels>(sql, (room_level, level, room) => { room_level.Level = level; room_level.Room = room;  return room_level; }, new { room_id = room_id, level_id = level_id }).SingleOrDefault();

        }
        //Dynamic way to keep track of every room with its level_id. Every room has its own id and level_id as well for scored sake.
        public void updateRoomLevel(Room_levels roomLevel)
        {
            string sql = "UPDATE Room_Levels SET isUnlocked = @isUnlocked, isCompleted = @isCompleted, savedScore = @savedScore where room_id = @room_id AND level_id = @level_id ";
            con.Execute(sql, new {isUnlocked = roomLevel.IsUnlocked, isCompleted = roomLevel.IsCompleted, savedScore = roomLevel.SavedScore, room_id = roomLevel.Room.ID, level_id = roomLevel.Level.ID });
        }
    }


}
