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

        public List<Room_levels> getRoom_Levels(int room_id)
        {
            string sql = "SELECT * from Room_levels where room_id = @room_id";
            return con.Query<Room_levels>(sql, new { room_id = room_id }).ToList();
        }
    }
}
