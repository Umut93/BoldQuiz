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

        
        //Joining af de to tabeller, deres information befolker jeg på hver af deres objekter
        //Return a list of specific levels on a specific room based on the roomID.
        //Multimapping in Dapper: map a single row to multiple objects (linie 24)
        public List<Room_levels> getRoom_Levels(int room_id)
        {
            string sql = "SELECT * FROM Room_levels JOIN [Level] on level_id = Level.ID where room_id = @room_id";
            return con.Query<Room_levels, Level, Room_levels>(sql, (room_level, level) => { room_level.Level = level; return room_level; }, new { room_id = room_id }).ToList();

        }

        //Getting one specific level on a specific room. The first overload!
        public Room_levels getRoom_level(int room_level_id)
        {
            string sql = "SELECT * FROM Room_levels JOIN [Level] on level_id = Level.ID JOIN Room on room_id = Room.ID where Room_levels.ID =@room_level_id";
            return con.Query<Room_levels, Level, Room, Room_levels>(sql, (room_level, level, room) => { room_level.Level = level; room_level.Room = room; return room_level; }, new { room_level_id = room_level_id }).SingleOrDefault();

        }


        // Getting a specific level on a specific room by searhing the roomid and the level id.
        //Second overload.
        //SingleOrDefault: If the sequnce is empty or if no conditions is not satified --> no error. Throw a exception if one more element in the sequense satifies the given condition.
        public Room_levels getRoom_level(int room_id, int level_id)
        {
            string sql = "SELECT * FROM Room_levels JOIN [Level] on level_id = Level.ID JOIN Room on room_id = Room.ID where room_id = @room_id AND level_id = @level_id";
            return con.Query<Room_levels, Level, Room, Room_levels>(sql, (room_level, level, room) => { room_level.Level = level; room_level.Room = room;  return room_level; }, new { room_id = room_id, level_id = level_id }).SingleOrDefault();
            
        }
        
        //Updating a room_level based on the room and level you are on. Pay attention isCompleted is not used at all, but other columns are used.

        public void updateRoomLevel(Room_levels roomLevel)
        {
            string sql = "UPDATE Room_Levels SET isCompleted = @isCompleted where room_id = @room_id AND level_id = @level_id ";
            con.Execute(sql, new { isCompleted = roomLevel.IsCompleted, room_id = roomLevel.Room.ID, level_id = roomLevel.Level.ID });
        }

        // Inserting values into Room_levels based on the room and level you are on. 
        public void addRoomLevel(Room_levels roomLevel)
        {
            string sql = "INSERT INTO Room_levels VALUES (@isCompleted, @room_id, @level_id)";
            con.Execute(sql, new { isCompleted = roomLevel.IsCompleted, room_id = roomLevel.Room.ID, level_id = roomLevel.Level.ID});
        }
    }




}
