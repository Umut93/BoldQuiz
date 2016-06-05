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

        //Room_Levels id og Level id joines i forbindelse med det room man er i. Joining af de to tabeller, deres information befolker jeg på hver af deres objekter
        //Returner liste over de LEVELS man er i ud fra sit room_id!!!
        //Multimapping in Dapper: map a single row to multiple objects
        public List<Room_levels> getRoom_Levels(int room_id)
        {
            string sql = "SELECT * FROM Room_levels JOIN [Level] on level_id = Level.ID where room_id = @room_id";
            return con.Query<Room_levels, Level, Room_levels>(sql, (room_level, level) => { room_level.Level = level; return room_level; }, new { room_id = room_id }).ToList();

        }

        //Getting one specific room with its room_level. The first overload!
        public Room_levels getRoom_level(int room_level_id)
        {
            string sql = "SELECT * FROM Room_levels JOIN [Level] on level_id = Level.ID JOIN Room on room_id = Room.ID where Room_levels.ID =@room_level_id";
            return con.Query<Room_levels, Level, Room, Room_levels>(sql, (room_level, level, room) => { room_level.Level = level; room_level.Room = room; return room_level; }, new { room_level_id = room_level_id }).SingleOrDefault();

        }


        // Joiner Room_levels + Level + Room -> returnerer Room_levels. Dette tages højde for hvilket rum og level man er i.
        //Viser EN Room_level ud fra det room og level man er id.
        //Second overload.
        //SingleOrDefault: If the sequnce is empty or if no conditions is not satified --> no error. Throw a exception if one more element in the sequense satifies the given condition.
        public Room_levels getRoom_level(int room_id, int level_id)
        {
            string sql = "SELECT * FROM Room_levels JOIN [Level] on level_id = Level.ID JOIN Room on room_id = Room.ID where room_id = @room_id AND level_id = @level_id";
            return con.Query<Room_levels, Level, Room, Room_levels>(sql, (room_level, level, room) => { room_level.Level = level; room_level.Room = room;  return room_level; }, new { room_id = room_id, level_id = level_id }).SingleOrDefault();
            
        }
        
        //Updating a room_level table after processing the quiz based on the room and level you are on.
        public void updateRoomLevel(Room_levels roomLevel)
        {
            string sql = "UPDATE Room_Levels SET isCompleted = @isCompleted where room_id = @room_id AND level_id = @level_id ";
            con.Execute(sql, new { isCompleted = roomLevel.IsCompleted, room_id = roomLevel.Room.ID, level_id = roomLevel.Level.ID });
        }

        // Inserting values into Room_levels (table). 
        public void addRoomLevel(Room_levels roomLevel)
        {
            string sql = "INSERT INTO Room_levels VALUES (@isCompleted, @room_id, @level_id)";
            con.Execute(sql, new { isCompleted = roomLevel.IsCompleted, room_id = roomLevel.Room.ID, level_id = roomLevel.Level.ID});
        }
    }




}
