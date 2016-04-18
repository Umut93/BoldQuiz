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
    }
}
